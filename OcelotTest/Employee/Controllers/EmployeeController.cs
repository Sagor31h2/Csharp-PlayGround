using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetEmployee()
        {
            var emp = new
            {
                Name = "sagor",
                Type = "Employee"
            };
            return Ok(emp);
        }
    }
}