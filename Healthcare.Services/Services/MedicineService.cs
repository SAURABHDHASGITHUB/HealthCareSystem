using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.Medicine;
using Healthcare.Infrastructure.Models;
using Healthcare.Repository;
using Healthcare.Services.Interfaces;

namespace Healthcare.Services.Services
{
    public class MedicineService:IMedicineService
    {
        private readonly IGenericRepository<Medicine> _medicineRepo;

        public MedicineService(IGenericRepository<Medicine> medicineRepo)
        {
            _medicineRepo = medicineRepo;
        }
        public async Task<string> CreateMedicine(CreateMedicineDTO dto)
        {
            var medicine = new Medicine
            {
                MedicineName = dto.MedicineName,
                Description = dto.Description,
                Price = dto.Price
            };

            await _medicineRepo.AddAsync(medicine);

            await _medicineRepo.SaveAsync();

            return "Medicine created successfully";
        }

        public async Task<string> DeleteMedicine(int id)
        {
            var medicine = await _medicineRepo.GetByIdAsync(id);

            if (medicine == null)
                return "Medicine not found";

            _medicineRepo.Delete(medicine);

            await _medicineRepo.SaveAsync();

            return "Medicine deleted successfully";
        }

        public async Task<IEnumerable<Medicine>> GetAllMedicines()
        {
            return await _medicineRepo.GetAllAsync();
        }
    }
}
