using Stone.Integration.BusinessEntities;
using Stone.Integration.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Integration.Business
{
    public class TransactionBO
    {
        private static readonly TransactionBO instance = new TransactionBO();

        public static TransactionBO Instance
        {
            get
            {
                return instance;
            }
        }

        public IEnumerable<TransactionVO> GetAllTransactions()
        {
            return Transaction.Instance.GetAllTransactions();
        }
    }
}
