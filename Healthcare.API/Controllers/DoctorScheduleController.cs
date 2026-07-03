using Healthcare.Core.DTOs.DoctorSchedule;
using Healthcare.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.API.Controllers
{
    [Authorize(Roles = "Admin,Doctor")]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorScheduleController : ControllerBase
    {
        private readonly IDoctorScheduleService _service;

        public DoctorScheduleController(IDoctorScheduleService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetSchedules()
        {
            var data = await _service.GetSchedules();

            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create( [FromBody] CreateDoctorScheduleDTO dto)
        {
            var result = await _service.CreateSchedule(dto);

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteSchedule(id);

            return Ok(result);
        }
    }
}
