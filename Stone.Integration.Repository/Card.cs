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
    public class Card : ICard
    {
        private static readonly Card instance = new Card();

        private readonly string cn = Connection.Cn;

        public static Card Instance
        {
            get
            {
                return instance;
            }
        }

        public IEnumerable<AuthorizationVO> GetAllCads()
        {
            List<AuthorizationVO> lstCliente = new List<AuthorizationVO>();

            try
            {
                using (SqlConnection con = new SqlConnection(cn))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_OBTER_CLIENTES";
                        cmd.Connection = con;
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            AuthorizationVO Cliente = new AuthorizationVO();

                            Cliente.CardholderName =  rdr["Nome"].ToString();
                            Cliente.Number = Convert.ToInt64(rdr["Numero"]);
                            Cliente.ExpirationDate = Convert.ToDateTime(rdr["Validade"]);
                            Cliente.CardBrand = rdr["Bandeira"].ToString();
                            Cliente.TypeCard =  rdr["TipoCartao"].ToString();
                            Cliente.Limit = Convert.ToDecimal(rdr["Limite"]);
                            Cliente.ActiveCard = rdr["Ativo"].ToString();

                            lstCliente.Add(Cliente);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return lstCliente;

        }

        public bool IncludeCard(AuthorizationVO card)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cn))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_CADASTRAR_CARTAO";
                        cmd.Connection = con;

                        cmd.Parameters.Add(new SqlParameter("@NOME", card.CardholderName));
                        cmd.Parameters.Add(new SqlParameter("@NUMERO", card.Number));
                        cmd.Parameters.Add(new SqlParameter("@VALIDADE", card.ExpirationDate));
                        cmd.Parameters.Add(new SqlParameter("@CODSEGURANCA", card.SecureCode));
                        cmd.Parameters.Add(new SqlParameter("@BANDEIRA", card.CardBrand));
                        cmd.Parameters.Add(new SqlParameter("@TIPOCARTAO", card.TypeCard));
                        cmd.Parameters.Add(new SqlParameter("@PASSWORD", card.Password));

                        if(card.TypeCard == "Tarjeta")
                            cmd.Parameters.Add(new SqlParameter("@HASPASSWORD", true));
                        else
                            cmd.Parameters.Add(new SqlParameter("@HASPASSWORD", false));

                        cmd.Parameters.Add(new SqlParameter("@LIMITE", card.Limit));

                        if(card.ActiveCard == "Habilitado")
                        {
                            cmd.Parameters.Add(new SqlParameter("@ATIVO", "S"));
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@ATIVO", "N"));
                        }

                        if (cmd.ExecuteNonQuery() > 0)
                            return true;
                        else
                            return false;

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
