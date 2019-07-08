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
    public class Transaction : ITransaction
    {
        private static readonly Transaction instance = new Transaction();

        private readonly string cn = Connection.Cn;

        public static Transaction Instance
        {
            get
            {
                return instance;
            }
        }

        public IEnumerable<TransactionVO> GetAllTransactions()
        {
            List<TransactionVO> lstTransactions = new List<TransactionVO>();

            try
            {
                using (SqlConnection con = new SqlConnection(cn))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "PR_OBTER_TRANSACOES";
                        cmd.Connection = con;
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            TransactionVO transaction = new TransactionVO();

                            transaction.Token = rdr["Token"].ToString();
                            transaction.Amount= Convert.ToDecimal(rdr["ValorTransacao"]);
                            transaction.Type = rdr["TipoTransacao"].ToString();
                            transaction.QuantityPlots = Convert.ToInt32(rdr["NumeroParcelas"]);
                            transaction.PlotValue = Convert.ToDecimal(rdr["ValorParcela"]);

                            lstTransactions.Add(transaction);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return lstTransactions;

        }

        public bool IncludeTransaction(TransactionVO transacao, int idAuthorization)
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
                        cmd.CommandText = "PR_CADASTRAR_TRANSACAO";
                        cmd.Connection = con;

                        cmd.Parameters.Add(new SqlParameter("@IDCARTAO", idAuthorization));
                        cmd.Parameters.Add(new SqlParameter("@VALORTRANSACAO", transacao.Amount));
                        cmd.Parameters.Add(new SqlParameter("@TIPOTRANSACAO", transacao.Type));
                        cmd.Parameters.Add(new SqlParameter("@NUMEROPARCELAS", transacao.QuantityPlots));
                        cmd.Parameters.Add(new SqlParameter("@VALORPARCELA", transacao.PlotValue));
                        cmd.Parameters.Add(new SqlParameter("@TOKEN", Guid.NewGuid().ToString()));

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
