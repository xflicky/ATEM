using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }
    
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<AttendanceRecord> AttendanceRecords { get; set; }
    public DbSet<TimeOff> TimeOffs { get; set; }
    public DbSet<SickDay> SickDays { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>()
            .HasMany(d => d.Employees)
            .WithOne(e => e.Department) 
            .HasForeignKey(e => e.DepartmentId);

        modelBuilder.Entity<Department>()
            .HasOne(d => d.Supervisor)
            .WithMany()
            .HasForeignKey(d => d.SupervisorId);

        modelBuilder.Entity<AttendanceRecord>()
            .HasOne(e => e.Employee)
            .WithMany()
            .HasForeignKey("EmployeeId");
     
        modelBuilder.Entity<TimeOff>()
            .HasOne(e => e.Employee)
            .WithMany()
            .HasForeignKey("EmployeeId");

        modelBuilder.Entity<SickDay>()
            .HasOne(e => e.Employee)
            .WithMany()
            .HasForeignKey("EmployeeId");
    }
}