using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Integration.BusinessEntities
{
    public class ResultAuthorization
    {
        public int IdCard { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Limit { get; set; }
        public string ActiveCard { get; set; }
        public string MessageReturn { get; set; }
        public bool IsAuthorized { get; set; }
    }
}
