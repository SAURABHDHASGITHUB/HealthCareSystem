using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.Patient;
using Healthcare.Infrastructure.Data;
using Healthcare.Infrastructure.Models;
using Healthcare.Services.Interfaces;
using Healthcare.Repository;
using Healthcare.Core.Exceptions;

namespace Healthcare.Services.Services
{
    public class PatientService : IPatientService
    {
       private readonly IGenericRepository<Patient> _patientRepo;
        private readonly HealthcareDbContext _context;
        public PatientService(IGenericRepository<Patient>  patientRepo, HealthcareDbContext context)
        {
            _patientRepo = patientRepo;
            _context = context;
        }
        //public async Task<int> CreatePatient(PatientDTO dto)
        //{
            //if (dto == null)
            //    throw new BadRequestException("Invalid patient data");

            //var email = dto.Email.Trim().ToLowerInvariant();


            //var existing = await _patientRepo
            //.FirstOrDefaultAsync(x => x.Email.ToLower() == email);


            //if (existing != null)
            //    throw new ConflictException("Patient already exists with this email");


           // var patient = new Patient
           // {
           //     UserId = dto.UserId,
           //     Name = dto.Name,
           //     Age = dto.Age,
           //     Gender = dto.Gender,
           //     Phone = dto.Phone,
           //     //Email = dto.Email,
           //     Address = dto.Address
           // };

           //await _patientRepo.AddAsync(patient);

           // await _patientRepo.SaveAsync();

           // return patient.PatientId;
        //}

        public async Task<bool> DeletePatient(int patientId)
        {

            var patient = await _context.Patients.FindAsync(patientId);

            if (patient == null)
                throw new NotFoundException("Patient not found");

            // Step 1: Get appointments
            var appointments = await _context.Appointments
                .Where(a => a.PatientId == patientId)
                .ToListAsync();

            var appointmentIds = appointments.Select(a => a.AppointmentId).ToList();

            // Step 2: Get prescriptions
            var prescriptions = await _context.Prescriptions
                .Where(p => appointmentIds.Contains((int)p.AppointmentId))
                .ToListAsync();

            var prescriptionIds = prescriptions.Select(p => p.PrescriptionId).ToList();

            // 🔥 Step 3: Delete PrescriptionMedicines FIRST
            var medicines = await _context.PrescriptionMedicines
                .Where(pm => prescriptionIds.Contains((int)pm.PrescriptionId))
                .ToListAsync();

            _context.PrescriptionMedicines.RemoveRange(medicines);

            // Step 4: Delete Prescriptions
            _context.Prescriptions.RemoveRange(prescriptions);

            // Step 5: Delete Appointments
            _context.Appointments.RemoveRange(appointments);

            // Step 6: Delete Patient
            _context.Patients.Remove(patient);

            // Step 7: Delete User (if not doctor)
            var isDoctor = await _context.Doctors
                .AnyAsync(d => d.UserId == patient.UserId);

            if (!isDoctor)
            {
                var user = await _context.Users.FindAsync(patient.UserId);
                if (user != null)
                    _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<PatientDTO>> GetAllPatients(int page, int pageSize)
        {
            var patients = await  _patientRepo.GetAllAsync();

            var pagedData = patients
           .Skip((page - 1) * pageSize)
           .Take(pageSize)
           .ToList();


            if (!patients.Any())
                return new List<PatientDTO>();


            //if (patients == null || !patients.Any())
            //    throw new NotFoundException("No patients found");

            var result= pagedData.Select(p => new PatientDTO
            {
                PatientId = p.PatientId,
                Name = p.Name,
                Age = p.Age,
                Phone = p.Phone,
                Gender=p.Gender,
                Address=p.Address
            }).ToList();

            return result;



        }

        public async Task<PatientDTO> GetPatientById(int id)
        {
            var patient = await _patientRepo.GetByIdAsync(id);

            if (patient == null)
                throw new NotFoundException("Patient not found");


            return new PatientDTO
            {
                PatientId = patient.PatientId,
                Name = patient.Name,
                Age =  patient.Age,
                Gender = patient.Gender,
                Phone = patient.Phone,
                //Email = patient.Email,
                Address = patient.Address
            };

        }
    }
}
