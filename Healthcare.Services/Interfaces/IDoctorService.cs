using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.Doctor;
using Healthcare.Infrastructure.Models;

namespace Healthcare.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllDoctors();

        Task<string> CreateDoctor(CreateDoctorDTO dto);

        Task<string> UpdateDoctor(UpdateDoctorDTO dto);

        Task<string> DeleteDoctor(int id);
    }
}
