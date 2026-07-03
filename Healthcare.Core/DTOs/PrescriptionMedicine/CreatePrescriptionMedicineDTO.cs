using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Core.DTOs.PrescriptionMedicine
{
    public class CreatePrescriptionMedicineDTO
    {
        public int PrescriptionId { get; set; }

        public int MedicineId { get; set; }

        public string Dosage { get; set; }

        public string Duration { get; set; }
    }
}
