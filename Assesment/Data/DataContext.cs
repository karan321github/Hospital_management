using Assesment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<TestReport> TestReports { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Doctor>()
            .HasOne(d => d.Employee)
            .WithOne(e => e.Doctor) // Assuming a bi-directional relationship
            .HasForeignKey<Doctor>(d => d.EId)
            .OnDelete(DeleteBehavior.Cascade);
            // Many-to-Many: Patient-Doctor
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Doctors)
                .WithMany(d => d.Patients)
                .UsingEntity(j => j.ToTable("PatientDoctor"));

            // Many-to-Many: Nurse-Room
            modelBuilder.Entity<Nurse>()
                .HasMany(n => n.Rooms)
                .WithMany(r => r.Nurses)
                .UsingEntity(j => j.ToTable("NurseRoom"));

            // Many-to-Many: Receptionist-Records
            modelBuilder.Entity<Receptionist>()
                .HasMany(r => r.Records)
                .WithMany(r => r.Receptionists)
                .UsingEntity(j => j.ToTable("ReceptionistRecords"));
        }

    }

}
