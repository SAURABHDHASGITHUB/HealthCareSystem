using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Infrastructure.Models;

public partial class PrescriptionMedicine
{
    [Key]
    public int Id { get; set; }

    public int? PrescriptionId { get; set; }

    public int? MedicineId { get; set; }

    [StringLength(50)]
    public string? Dosage { get; set; }

    [StringLength(50)]
    public string? Duration { get; set; }

    [ForeignKey("MedicineId")]
    [InverseProperty("PrescriptionMedicines")]
    public virtual Medicine? Medicine { get; set; }

    [ForeignKey("PrescriptionId")]
    [InverseProperty("PrescriptionMedicines")]
    public virtual Prescription? Prescription { get; set; }
}
