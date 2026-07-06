using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.Patient;
using Healthcare.Infrastructure.Models;

namespace Healthcare.Services.Interfaces
{
    public interface IPatientService
    {
        Task<List<PatientDTO>> GetAllPatients(int page, int pageSize);
        Task<PatientDTO> GetPatientById(int id);

        //Task<int> CreatePatient(PatientDTO dto);

        Task<bool> DeletePatient(int patientId);

        //IPatientService interface
    }
}
