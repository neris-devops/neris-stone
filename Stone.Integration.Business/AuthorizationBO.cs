using Stone.Integration.BusinessEntities;
using Stone.Integration.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Integration.Business
{
    public class AuthorizationBO
    {
        private static readonly AuthorizationBO instance = new AuthorizationBO();

        public static AuthorizationBO Instance
        {
            get
            {
                return instance;
            }
        }

        public bool IncludeCard(AuthorizationVO card)
        {
            return Card.Instance.IncludeCard(card);
        }

        public IEnumerable<AuthorizationVO> GetAllCads()
        {
            return Card.Instance.GetAllCads();
        }

        public IEnumerable<ResultAuthorization> GetAuthorization(AuthorizationVO card)
        {
            return Authorization.Instance.GetAuthorization(card);
        }
    }
}
