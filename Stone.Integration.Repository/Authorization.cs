using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stone.Integration.BusinessEntities;
using Stone.Integration.Others;

namespace Stone.Integration.Repository
{
    public class Authorization : IAuthorization
    {
        private static readonly Authorization instance = new Authorization();

        private readonly string cn = Connection.Cn;

        public static Authorization Instance
        {
            get
            {
                return instance;
            }
        }

        public IEnumerable<ResultAuthorization> GetAuthorization(AuthorizationVO card)
        {
            List<ResultAuthorization> lstAuthorization = new List<ResultAuthorization>();

            ResultAuthorization result = new ResultAuthorization();

            try
            {
                using (SqlConnection con = new SqlConnection(cn))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_OBTER_AUTORIZACAO";
                        cmd.Connection = con;

                        cmd.Parameters.Add(new SqlParameter("@NOME", card.CardholderName));
                        cmd.Parameters.Add(new SqlParameter("@NUMERO", card.Number));
                        cmd.Parameters.Add(new SqlParameter("@VALIDADE", card.ExpirationDate));
                        cmd.Parameters.Add(new SqlParameter("@CODSEGURANCA", card.SecureCode));

                        SqlDataReader rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            result.IdCard = Convert.ToInt32(rdr["IdCartao"]);
                            result.ExpirationDate = Convert.ToDateTime(rdr["Validade"]);
                            result.Limit = Convert.ToDecimal(rdr["Limite"]);
                            result.ActiveCard = rdr["Ativo"].ToString();

                            if (result.ActiveCard.Equals("N"))
                            {
                                result.MessageReturn = "Cartão bloqueado";
                                CheckOPeration(ref lstAuthorization, ref result, false);
                                return lstAuthorization;
                            }

                            if (result.ExpirationDate <= DateTime.Now.Date)
                            {
                                result.MessageReturn = "Transação negada";
                                CheckOPeration(ref lstAuthorization, ref result, false);
                                return lstAuthorization;
                            }

                            if (card.Transcao.Amount < Convert.ToDecimal(0.10))
                            {
                                result.MessageReturn = "Mínimo de 10 centavos";
                                CheckOPeration(ref lstAuthorization, ref result, false);
                                return lstAuthorization;
                            }

                            if (result.Limit < card.Transcao.Amount)
                            {
                                result.MessageReturn = "Portador do cartão não possui saldo";
                                CheckOPeration(ref lstAuthorization, ref result, false);
                                return lstAuthorization;
                            }

                            if (Transaction.Instance.IncludeTransaction(card.Transcao, result.IdCard))
                            {
                                result.MessageReturn = "Transação aprovada";
                                CheckOPeration(ref lstAuthorization, ref result, true);
                                return lstAuthorization;
                            }
                            else
                            {
                                result.MessageReturn = "Transação negada";
                                CheckOPeration(ref lstAuthorization, ref result, false);
                                return lstAuthorization;
                            }
                        }

                        result.MessageReturn = "Cartão não encontrado, por favor, cadastre o cartão";
                        CheckOPeration(ref lstAuthorization, ref result, false);

                    }
                }
            }
            catch (Exception ex)
            {
                result.MessageReturn = "Falha na autorização";
                CheckOPeration(ref lstAuthorization, ref result, false);
            }

            return lstAuthorization;

        }

        void CheckOPeration(ref List<ResultAuthorization> lstAuthorization, ref ResultAuthorization result, bool status)
        {
            result.IsAuthorized = status;
            lstAuthorization.Add(result);
        }
    }
}
