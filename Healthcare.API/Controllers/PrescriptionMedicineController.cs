using Healthcare.Core.DTOs.PrescriptionMedicine;
using Healthcare.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.API.Controllers
{
    [Authorize(Roles = "Doctor")]
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionMedicineController : ControllerBase
    {
        private readonly IPrescriptionMedicineService _service;


        public PrescriptionMedicineController(IPrescriptionMedicineService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatePrescriptionMedicineDTO dto)
        {
            var result = await _service.AddMedicine(dto);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetPrescriptionMedicines();

            return Ok(data);
        }

    }
}
