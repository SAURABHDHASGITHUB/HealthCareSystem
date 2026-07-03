using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Core.DTOs.Medicine
{
    public class CreateMedicineDTO
    {
        public string MedicineName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
