using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.Prescription;
using Healthcare.Infrastructure.Models;
using Healthcare.Repository;
using Healthcare.Services.Interfaces;

namespace Healthcare.Services.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IGenericRepository<Prescription> _prescriptionRepo;
        private readonly IGenericRepository<Appointment> _appointmentRepo;

        public PrescriptionService(
        IGenericRepository<Prescription> prescriptionRepo,
        IGenericRepository<Appointment> appointmentRepo)
        {
            _prescriptionRepo = prescriptionRepo;
            _appointmentRepo = appointmentRepo;
        }
        public async Task<string> CreatePrescription(CreatePrescriptionDTO dto)
        {
            var appointment = await _appointmentRepo.GetByIdAsync(dto.AppointmentId);

            if (appointment == null)
                return "Appointment not found";

            var prescription = new Prescription
            {
                AppointmentId = dto.AppointmentId,
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,
                Notes = dto.Notes,
                CreatedDate = DateTime.Now
            };

            await _prescriptionRepo.AddAsync(prescription);

            await _prescriptionRepo.SaveAsync();

            return "Prescription created successfully";
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _prescriptionRepo.GetAllAsync();
        }
    }
}
