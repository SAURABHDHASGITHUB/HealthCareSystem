using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.Medicine;
using Healthcare.Infrastructure.Models;

namespace Healthcare.Services.Interfaces
{
    public interface IMedicineService
    {
        Task<IEnumerable<Medicine>> GetAllMedicines();

        Task<string> CreateMedicine(CreateMedicineDTO dto);

        Task<string> DeleteMedicine(int id);
        //  IMedicineService Interface
    }
}
