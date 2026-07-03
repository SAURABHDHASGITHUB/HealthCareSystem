using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.DoctorSchedule;
using Healthcare.Infrastructure.Data;
using Healthcare.Infrastructure.Models;
using Healthcare.Services.Interfaces;

namespace Healthcare.Services.Services
{
    public class DoctorScheduleService : IDoctorScheduleService
    {
        private readonly HealthcareDbContext _context;

        public DoctorScheduleService(HealthcareDbContext context)
        {
            _context = context;
        }


        public async Task<string> CreateSchedule(CreateDoctorScheduleDTO dto)
        {
            var schedule = new DoctorSchedule
            {
                DoctorId = dto.DoctorId,
                AvailableDate = dto.AvailableDate,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime
            };

            _context.DoctorSchedules.Add(schedule);

            await _context.SaveChangesAsync();

            return "Schedule created successfully";
        }

        public async Task<string> DeleteSchedule(int id)
        {
            var schedule = await _context.DoctorSchedules.FindAsync(id);

            if (schedule == null)
                return "Schedule not found";

            _context.DoctorSchedules.Remove(schedule);

            await _context.SaveChangesAsync();

            return "Schedule deleted";
        }

        public async Task<List<DoctorSchedule>> GetSchedules()
        {
            return await _context.DoctorSchedules
                .Include(x => x.Doctor)
                .ToListAsync();
        }
    }
}
