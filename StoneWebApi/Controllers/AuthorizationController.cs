using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stone.Integration.Business;
using Stone.Integration.BusinessEntities;
using Microsoft.AspNetCore.Mvc;

namespace StoneWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Card")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        [HttpGet("GetAllCards")]
        public ActionResult<IEnumerable<AuthorizationVO>> GetAllCards()
        {
            try
            {
                return AuthorizationBO.Instance.GetAllCads().ToList();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("GetAuthorization")]
        public ActionResult<IEnumerable<ResultAuthorization>> GetAuthorization([FromBody] AuthorizationVO card)
        {
            try
            {
                return AuthorizationBO.Instance.GetAuthorization(card).ToList();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("IncludeCard")]
        public ActionResult<bool> IncludeCard([FromBody] AuthorizationVO card)
        {
            try
            {
                return AuthorizationBO.Instance.IncludeCard(card);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
