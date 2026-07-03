using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.Payment;
using Healthcare.Infrastructure.Models;
using Healthcare.Repository;
using Healthcare.Services.Interfaces;

namespace Healthcare.Services.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IGenericRepository<Payment> _paymentRepository;
        private readonly IGenericRepository<Appointment> _appointmentRepository;

        public PaymentService(IGenericRepository<Payment> paymentRepository
                             ,IGenericRepository<Appointment> appointmentRepository)
        {
            _paymentRepository = paymentRepository;
            _appointmentRepository = appointmentRepository;
        }
        public async Task<string> CreatePayment(CreatePaymentDTO dto)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(dto.AppointmentId);

            if (appointment == null)
                return "Appointment not found";

            var payment = new Payment
            {
                AppointmentId = dto.AppointmentId,
                Amount = dto.Amount,
                PaymentDate = DateTime.Now,
                PaymentMethod = dto.PaymentMethod,
                PaymentStatus = "Completed"
            };

            await _paymentRepository.AddAsync(payment);
            await _paymentRepository.SaveAsync();

            return "Payment recorded successfully";



        }

        public async Task<IEnumerable<Payment>> GetPayments()
        {
            return await _paymentRepository.GetAllAsync();
        }
    }
}
