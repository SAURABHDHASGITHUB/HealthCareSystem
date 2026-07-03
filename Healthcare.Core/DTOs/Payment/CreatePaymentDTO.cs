using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Core.DTOs.Payment
{
    public class CreatePaymentDTO
    {
        public int AppointmentId { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }
    }
}
