using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.PrescriptionMedicine;
using Healthcare.Infrastructure.Models;

namespace Healthcare.Services.Interfaces
{
    public interface IPrescriptionMedicineService
    {
        Task<string> AddMedicine(CreatePrescriptionMedicineDTO dto);

        Task<IEnumerable<PrescriptionMedicine>> GetPrescriptionMedicines();

    }
}
