using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.Appointment;
using Healthcare.Infrastructure.Models;

namespace Healthcare.Services.Interfaces
{
    
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAppointments();

        Task<string> BookAppointment(BookAppointmentDTO dto);

        Task<string> CancelAppointment(int id);
        //IAppointmentService  interface from init
    }
}
