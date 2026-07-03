using System;
using System.Collections.Generic;
using Healthcare.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Infrastructure.Data;

public partial class HealthcareDbContext : DbContext
{
    public HealthcareDbContext()
    {
    }

    public HealthcareDbContext(DbContextOptions<HealthcareDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<DoctorSchedule> DoctorSchedules { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SAURABH\\SQLEXPRESS;Database=HealthcareSystem;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC26B86853B");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments).HasConstraintName("FK__Appointme__Docto__5BE2A6F2");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments).HasConstraintName("FK__Appointme__Patie__5CD6CB2B");

            entity.HasOne(d => d.Schedule).WithMany(p => p.Appointments).HasConstraintName("FK__Appointme__Sched__5DCAEF64");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__AuditLog__5E548648B2B9CF5A");

            entity.Property(e => e.Timestamp).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED593F3CD3");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctors__2DC00EBFC8809FFB");

            entity.HasOne(d => d.Department).WithMany(p => p.Doctors).HasConstraintName("FK__Doctors__Departm__52593CB8");

            entity.HasOne(d => d.User).WithMany(p => p.Doctors).HasConstraintName("FK__Doctors__UserId__5165187F");
        });

        modelBuilder.Entity<DoctorSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__DoctorSc__9C8A5B4988BB3A5A");

            entity.HasOne(d => d.Doctor).WithMany(p => p.DoctorSchedules).HasConstraintName("FK__DoctorSch__Docto__5812160E");
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.MedicineId).HasName("PK__Medicine__4F212890F825BBC2");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC366988E2145");

            entity.HasOne(d => d.User).WithMany(p => p.Patients).HasConstraintName("FK__Patients__UserId__5535A963");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A3874D00A37");

            entity.HasOne(d => d.Appointment).WithMany(p => p.Payments).HasConstraintName("FK__Payments__Appoin__6A30C649");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PK__Prescrip__40130832DC978AE3");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Appointment).WithMany(p => p.Prescriptions).HasConstraintName("FK__Prescript__Appoi__619B8048");
        });

        modelBuilder.Entity<PrescriptionMedicine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prescrip__3214EC0776C89B51");

            entity.HasOne(d => d.Medicine).WithMany(p => p.PrescriptionMedicines).HasConstraintName("FK__Prescript__Medic__6754599E");

            entity.HasOne(d => d.Prescription).WithMany(p => p.PrescriptionMedicines).HasConstraintName("FK__Prescript__Presc__66603565");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A10D508B6");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C9838A817");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Role).WithMany(p => p.Users).HasConstraintName("FK__Users__RoleId__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
