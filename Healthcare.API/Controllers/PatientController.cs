using Healthcare.Core.Common;
using Healthcare.Core.DTOs.Patient;
using Healthcare.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.API.Controllers

{
    //[Authorize(Roles = "Admin")]
    [Route("api/patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page =1, int pageSize=20)
        {
            var patients = await _service.GetAllPatients(page, pageSize);

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Patients Get successfully",
                Data = patients
            });
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(PatientDTO dto)
        //{
        //    var id = await _service.CreatePatient(dto);

        //    return Ok(new ApiResponse<int>
        //    {
        //        Success = true,
        //        Message = "Patient created successfully",
        //        Data = id
        //    });
        //}


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _service.GetPatientById(id);

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Patient fetched successfully",
                Data = patient
            });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeletePatient(id);

            return Ok(new ApiResponse<string>
            {
                Success = true,
                Message = "Patient deleted successfully",
                Data = null
            });
        }


    }
}
