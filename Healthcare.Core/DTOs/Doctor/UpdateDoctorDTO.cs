using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Core.DTOs.Doctor
{
    public class UpdateDoctorDTO
    {
        public int DoctorId { get; set; }

        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public string Specialization { get; set; }

        public int Experience { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
