using Healthcare.Core.DTOs.Appointment;
using Healthcare.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;


        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var data = await _service.GetAppointments();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Book(BookAppointmentDTO dto)
        {
            var result = await _service.BookAppointment(dto);

            return Ok(result);
        }

        [HttpPut("cancel/{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            var result = await _service.CancelAppointment(id);

            return Ok(result);
        }


    }
}
