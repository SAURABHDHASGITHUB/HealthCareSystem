using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.DoctorSchedule;
using Healthcare.Infrastructure.Models;

namespace Healthcare.Services.Interfaces
{
    public interface IDoctorScheduleService
    {
        Task<List<DoctorSchedule>> GetSchedules();

        Task<string> CreateSchedule(CreateDoctorScheduleDTO dto);

        Task<string> DeleteSchedule(int id);

        // IDoctorScheduleService interface
    }
}
