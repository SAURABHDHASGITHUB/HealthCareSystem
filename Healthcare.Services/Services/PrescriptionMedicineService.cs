using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.PrescriptionMedicine;
using Healthcare.Infrastructure.Models;
using Healthcare.Repository;
using Healthcare.Services.Interfaces;

namespace Healthcare.Services.Services
{
    public class PrescriptionMedicineService : IPrescriptionMedicineService
    {
        private readonly IGenericRepository<PrescriptionMedicine> _pmRepo;
        private readonly IGenericRepository<Prescription> _prescriptionRepo;
        private readonly IGenericRepository<Medicine> _medicineRepo;


        public PrescriptionMedicineService(
        IGenericRepository<PrescriptionMedicine> pmRepo,
        IGenericRepository<Prescription> prescriptionRepo,
        IGenericRepository<Medicine> medicineRepo)
        {
            _pmRepo = pmRepo;
            _prescriptionRepo = prescriptionRepo;
            _medicineRepo = medicineRepo;
        }
        public async Task<string> AddMedicine(CreatePrescriptionMedicineDTO dto)
        {
            var prescription = await _prescriptionRepo.GetByIdAsync(dto.PrescriptionId);

            if (prescription == null)
                return "Prescription not found";

            var medicine = await _medicineRepo.GetByIdAsync(dto.MedicineId);

            if (medicine == null)
                return "Medicine not found";

            var pm = new PrescriptionMedicine
            {
                PrescriptionId = dto.PrescriptionId,
                MedicineId = dto.MedicineId,
                Dosage = dto.Dosage,
                Duration = dto.Duration
            };

            await _pmRepo.AddAsync(pm);

            await _pmRepo.SaveAsync();

            return "Medicine added to prescription successfully";
        }

        public async Task<IEnumerable<PrescriptionMedicine>> GetPrescriptionMedicines()
        {
            return await _pmRepo.GetAllAsync();
        }
    }
}
