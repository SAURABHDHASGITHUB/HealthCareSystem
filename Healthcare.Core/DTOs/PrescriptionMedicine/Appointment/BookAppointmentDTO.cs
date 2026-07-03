using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Core.DTOs.Appointment
{
    public class BookAppointmentDTO
    {
        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public int ScheduleId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Reason { get; set; }

    }
}
