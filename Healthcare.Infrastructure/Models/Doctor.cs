using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Infrastructure.Models;

public partial class Doctor
{
    [Key]
    public int DoctorId { get; set; }

    public int? UserId { get; set; }

    public int? DepartmentId { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    [StringLength(100)]
    public string? Specialization { get; set; }

    public int? Experience { get; set; }

    [StringLength(20)]
    public string? Phone { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    [InverseProperty("Doctor")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    [ForeignKey("DepartmentId")]
    [InverseProperty("Doctors")]
    public virtual Department? Department { get; set; }

    [InverseProperty("Doctor")]
    [JsonIgnore]
    public virtual ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();

    [ForeignKey("UserId")]
    [InverseProperty("Doctors")]
    public virtual User? User { get; set; }
}
