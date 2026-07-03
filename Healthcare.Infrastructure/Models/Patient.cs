using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Infrastructure.Models;

public partial class Patient
{
    [Key]
    public int PatientId { get; set; }

    public int? UserId { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    public int? Age { get; set; }

    [StringLength(10)]
    public string? Gender { get; set; }

    [StringLength(20)]
    public string? Phone { get; set; }

   
    [StringLength(200)]
    public string? Address { get; set; }

    [InverseProperty("Patient")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    [ForeignKey("UserId")]
    [InverseProperty("Patients")]

    [JsonIgnore]
    public virtual User? User { get; set; }
}
