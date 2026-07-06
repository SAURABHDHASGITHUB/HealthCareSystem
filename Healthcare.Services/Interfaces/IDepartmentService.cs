using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.Department;
using Healthcare.Infrastructure.Models;

namespace Healthcare.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartments();

        Task<string> CreateDepartment(CreateDepartmentDTO dto);

        Task<string> UpdateDepartment(UpdateDepartmentDTO dto);

        Task<string> DeleteDepartment(int id);
        // add commits in interface
    }
}
