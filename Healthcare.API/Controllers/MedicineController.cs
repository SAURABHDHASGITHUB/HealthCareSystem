using Healthcare.Core.DTOs.Medicine;
using Healthcare.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _service;

        public MedicineController(IMedicineService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllMedicines();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMedicineDTO dto)
        {
            var result = await _service.CreateMedicine(dto);

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteMedicine(id);

            return Ok(result);
        }

    }
}
