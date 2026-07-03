using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Infrastructure.Models;

public partial class Appointment
{
    [Key]
    public int AppointmentId { get; set; }

    public int? DoctorId { get; set; }

    public int? PatientId { get; set; }

    public int? ScheduleId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AppointmentDate { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    [StringLength(200)]
    public string? Reason { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [JsonIgnore]
    [ForeignKey("DoctorId")]
    [InverseProperty("Appointments")]
    public virtual Doctor? Doctor { get; set; }

    [JsonIgnore]
    [ForeignKey("PatientId")]
    [InverseProperty("Appointments")]
    public virtual Patient? Patient { get; set; }

    [InverseProperty("Appointment")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [InverseProperty("Appointment")]
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    [JsonIgnore]
    [ForeignKey("ScheduleId")]
    [InverseProperty("Appointments")]
    public virtual DoctorSchedule? Schedule { get; set; }
}
