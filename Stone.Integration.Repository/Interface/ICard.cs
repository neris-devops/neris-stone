using Stone.Integration.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Integration.Repository
{
    interface ICard
    {
        IEnumerable<AuthorizationVO> GetAllCads();
        bool IncludeCard(AuthorizationVO card);

    }
}
