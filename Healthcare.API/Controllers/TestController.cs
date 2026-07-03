using Healthcare.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly HealthcareDbContext _context;

        public TestController(HealthcareDbContext context)
        {
            _context = context;
        }

        [HttpGet("doctors")]
        public IActionResult GetDoctors()
        {
            var doctors = _context.Doctors.ToList();

            return Ok(doctors);
        }
    }
}
