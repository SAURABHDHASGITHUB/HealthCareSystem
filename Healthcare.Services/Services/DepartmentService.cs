using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.Department;
using Healthcare.Infrastructure.Data;
using Healthcare.Infrastructure.Models;
using Healthcare.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Services.Services
{
    public class DepartmentService: IDepartmentService
    {
        private readonly HealthcareDbContext _context;

        public DepartmentService(HealthcareDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<string> CreateDepartment(CreateDepartmentDTO dto)
        {
            var department = new Department
            {
                DepartmentName = dto.DepartmentName,
                Description = dto.Description
            };

            _context.Departments.Add(department);

            await _context.SaveChangesAsync();

            return "Department created successfully";
        }

        public async Task<string> UpdateDepartment(UpdateDepartmentDTO dto)
        {
            var dept = await _context.Departments.FindAsync(dto.DepartmentId);

            if (dept == null)
                return "Department not found";


            dept.DepartmentName = dto.DepartmentName;
            dept.Description = dto.Description;

            await _context.SaveChangesAsync();

            return "Department updated successfully";


        }

        public async Task<string> DeleteDepartment(int id)
        {
            var dept = await _context.Departments.FindAsync(id);

            if (dept == null)
                return "Department not found";

            _context.Departments.Remove(dept);

            await _context.SaveChangesAsync();

            return "Department deleted successfully";
        }
    }
}
