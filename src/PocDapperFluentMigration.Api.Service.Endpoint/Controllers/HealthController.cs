using Microsoft.AspNetCore.Mvc;

namespace PocDapperFluentMigration.Api.Service.Endpoint.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("health")]
    public class HealthController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("status")]
        public IActionResult Status() => Ok(new { result = true });
    }
}
