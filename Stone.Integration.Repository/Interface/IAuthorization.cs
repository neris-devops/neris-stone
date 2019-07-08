using Stone.Integration.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Integration.Repository
{
    interface IAuthorization
    {
        IEnumerable<ResultAuthorization> GetAuthorization(AuthorizationVO card);
    }
}
