using Healthcare.Core.DTOs.Doctor;
using Healthcare.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {

        private readonly IDoctorService _service;


        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await _service.GetAllDoctors();

            return Ok(doctors);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDoctorDTO dto)
        {
            var result = await _service.CreateDoctor(dto);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDoctorDTO dto)
        {
            var result = await _service.UpdateDoctor(dto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteDoctor(id);

            return Ok(result);
        }



    }
}
