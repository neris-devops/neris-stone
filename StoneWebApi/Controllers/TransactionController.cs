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
    [Route("api/Transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpGet("GetAllTransactions")]
        public ActionResult<IEnumerable<TransactionVO>> GetAllTransactions()
        {
            try
            {
                return TransactionBO.Instance.GetAllTransactions().ToList();
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
