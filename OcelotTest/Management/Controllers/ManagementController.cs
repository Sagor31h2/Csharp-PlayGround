using Microsoft.AspNetCore.Mvc;

namespace Management.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagementController : ControllerBase
    {

        private readonly ILogger<ManagementController> _logger;

        public ManagementController(ILogger<ManagementController> logger)
        {
            _logger = logger;
        }
      
        [HttpGet("GetManagement")]
        public async Task<IActionResult> GetManagement()
        {   
            var emp = new
            {
                Name = "xyz",
                Type = "Management"
            };
            return Ok(emp);
        }
    }
}