using Healthcare.Core.DTOs.Department;
using Healthcare.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllDepartments();

            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentDTO dto)
        {
            var result = await _service.CreateDepartment(dto);

            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateDepartmentDTO dto)
        {
            var result = await _service.UpdateDepartment(dto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteDepartment(id);

            return Ok(result);
        }
    }
}
