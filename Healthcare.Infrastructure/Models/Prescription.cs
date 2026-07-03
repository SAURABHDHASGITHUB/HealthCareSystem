using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Infrastructure.Models;

public partial class Prescription
{
    [Key]
    public int PrescriptionId { get; set; }

    public int? AppointmentId { get; set; }

    public int? DoctorId { get; set; }

    public int? PatientId { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [ForeignKey("AppointmentId")]
    [InverseProperty("Prescriptions")]
    public virtual Appointment? Appointment { get; set; }

    [InverseProperty("Prescription")]
    public virtual ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();
}
