using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.Prescription;
using Healthcare.Infrastructure.Models;

namespace Healthcare.Services.Interfaces
{
    public interface IPrescriptionService
    {
        Task<string> CreatePrescription(CreatePrescriptionDTO dto);

        Task<IEnumerable<Prescription>> GetPrescriptions();

        // IPrescriptionService interface
    }
}
