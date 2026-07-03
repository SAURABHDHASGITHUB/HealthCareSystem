using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.Doctor;
using Healthcare.Infrastructure.Data;
using Healthcare.Infrastructure.Models;
using Healthcare.Services.Interfaces;

namespace Healthcare.Services.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HealthcareDbContext _context;

        public DoctorService(HealthcareDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateDoctor(CreateDoctorDTO dto)
        {
            var doctor = new Doctor
            {
                UserId = dto.UserId,
                DepartmentId = dto.DepartmentId,
                Name = dto.Name,
                Specialization = dto.Specialization,
                Experience = dto.Experience,
                Phone = dto.Phone,
                Email = dto.Email
            };
            _context.Doctors.Add(doctor);

            await _context.SaveChangesAsync();

            return "Doctor created successfully";

        }

        public async Task<string> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
                return "Doctor not found";

            _context.Doctors.Remove(doctor);

            await _context.SaveChangesAsync();

            return "Doctor deleted successfully";

        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await _context.Doctors
                .Include(x=>x.Department)
                .ToListAsync();
        }

        public async Task<string> UpdateDoctor(UpdateDoctorDTO dto)
        {
            var doctor = await _context.Doctors.FindAsync(dto.DoctorId);

            if (doctor == null)
                return "Doctor not found";

            doctor.DepartmentId = dto.DepartmentId;
            doctor.Name = dto.Name;
            doctor.Specialization = dto.Specialization;
            doctor.Experience = dto.Experience;
            doctor.Phone = dto.Phone;
            doctor.Email = dto.Email;


            await _context.SaveChangesAsync();

            return "Doctor updated successfully";


        }
    }
}
