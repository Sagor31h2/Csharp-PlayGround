using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OcelotGetway.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcelotController : ControllerBase
    {
        [HttpGet("Test")]
        public async Task<IActionResult> Test()
        {
            return Ok("Done");
        }

    }
}
