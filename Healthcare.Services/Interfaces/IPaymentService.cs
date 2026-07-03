using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.Payment;
using Healthcare.Infrastructure.Models;

namespace Healthcare.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<string> CreatePayment(CreatePaymentDTO dto);

        Task<IEnumerable<Payment>> GetPayments();
    }
}
