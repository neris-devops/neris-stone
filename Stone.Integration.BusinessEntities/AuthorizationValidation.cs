using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icatu.Integration.BusinessEntities
{
    public class AuthorizationValidation
    {
        public bool ValidateCard(string card)
        {
            if (!string.IsNullOrEmpty(card))
            {
                if ((card.Length >= 12) && (card.Length <= 19))
                    return true;
                else
                    return false;
            }

            return true;
        }
    }
}
