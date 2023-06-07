using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUD_OPS.Models
{
    public partial class EmployeeServicesContext : DbContext
    {
        public EmployeeServicesContext()
        {
        }

        public EmployeeServicesContext(DbContextOptions<EmployeeServicesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblEmployee> TblEmployees { get; set; } = null!;
        public virtual DbSet<TblEmployeeAttendance> TblEmployeeAttendances { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-6H5N4R8\\SQLEXPRESS;Initial Catalog=EmployeeServices;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("tblEmployee");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.Property(e => e.EmployeeCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employeeCode");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("employeeName");

                entity.Property(e => e.EmployeeSalary).HasColumnName("employeeSalary");
            });

            modelBuilder.Entity<TblEmployeeAttendance>(entity =>
            {
                entity.ToTable("tblEmployeeAttendance");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AttendanceDate)
                    .HasColumnType("datetime")
                    .HasColumnName("attendanceDate");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.Property(e => e.IsAbsent).HasColumnName("isAbsent");

                entity.Property(e => e.IsOffday).HasColumnName("isOffday");

                entity.Property(e => e.IsPresent).HasColumnName("isPresent");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TblEmployeeAttendances)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblEmployeeAttendance_tblEmployee1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
