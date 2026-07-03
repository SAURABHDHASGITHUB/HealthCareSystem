using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.Appointment;
using Healthcare.Core.DTOs.AuditLog;
using Healthcare.Infrastructure.Data;
using Healthcare.Infrastructure.Models;
using Healthcare.Repository;
using Healthcare.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Services.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly HealthcareDbContext _context;

        public AppointmentService(HealthcareDbContext context)
        {
            _context = context;
        }



        public async Task<string> BookAppointment(BookAppointmentDTO dto)
        {
            // Check doctor
            var doctor = await _context.Doctors.FindAsync(dto.DoctorId);
            if (doctor == null)
                return "Doctor not found";

            // Check patient
            var patient = await _context.Patients.FindAsync(dto.PatientId);
            if (patient == null)
                return "Patient not found";

            // Check schedule
            var schedule = await _context.DoctorSchedules.FindAsync(dto.ScheduleId);
            if (schedule == null)
                return "Doctor schedule not found";

            // Check appointment time inside schedule
            var appointmentTime = dto.AppointmentDate.TimeOfDay;

            if (appointmentTime < schedule.StartTime.Value.ToTimeSpan() ||
            appointmentTime > schedule.EndTime.Value.ToTimeSpan())
            {
            return "Doctor not available at this time";
            }

            // Prevent double booking
            var existingAppointment = await _context.Appointments
                .FirstOrDefaultAsync(x =>
                    x.DoctorId == dto.DoctorId &&
                    x.AppointmentDate == dto.AppointmentDate &&
                    x.Status != "Cancelled");

            if (existingAppointment != null)
                return "This time slot is already booked";

            // Create appointment
            var appointment = new Appointment
            {
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,
                ScheduleId = dto.ScheduleId,
                AppointmentDate = dto.AppointmentDate,
                Reason = dto.Reason,
                Status = "Pending",
                CreatedDate = DateTime.Now
            };

            _context.Appointments.Add(appointment);

            await _context.SaveChangesAsync();

            return "Appointment booked successfully";

        }

        public async Task<string> CancelAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
                return "Appointment not found";

            appointment.Status = "Cancelled";

            await _context.SaveChangesAsync();

            return "Appointment cancelled";
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _context.Appointments
                        .Include(x => x.Doctor)
                        .Include(x => x.Patient)
                        .ToListAsync();
        }
    }
}
