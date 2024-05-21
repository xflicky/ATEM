using api.Data;
using api.Models;
using api.QueryObjects;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDbContext _context;
    
    public DepartmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Department>> GetAllDepartmentsAsync(ActivityQueryParameter activityQueryParameter)
    {
        if (activityQueryParameter.Active)
        {
            return await _context.Departments
                .Where(d => !d.IsDeleted)
                .Include(d => d.Supervisor)
                .Include(d => d.Employees)
                .ToListAsync();
        }
        
        return await _context.Departments
            .Where(d => d.IsDeleted)
            .Include(d => d.Supervisor)
            .Include(d => d.Employees)
            .ToListAsync();
    }
    
    public async Task<Department> GetDepartmentByIdAsync(int id)
    {
        return await _context.Departments
            .Where(d => !d.IsDeleted && d.Id == id)
            .Include(d => d.Supervisor)
            .Include(d => d.Employees)
            .FirstAsync();
    }

    public async Task<Department> GetDepartmentInactiveByIdAsync(int id)
    {
        return await _context.Departments
            .Where(d => d.IsDeleted && d.Id == id)
            .Include(d => d.Supervisor)
            .Include(d => d.Employees)
            .FirstAsync();
    }

    public async Task<Department> CreateDepartmentAsync(Department department)
    {
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
        return department;
    }

    public async Task<Department> SetSupervisorToDepartmentAsync(int departmentId, int supervisorId)
    {   
        var supervisor = await _context.Employees.FindAsync(supervisorId);
        var department = await _context.Departments.FindAsync(departmentId);
        
        if (department!.SupervisorId != null)
        {
            var oldSupervisor = await _context.Employees.FindAsync(department.SupervisorId);
            oldSupervisor!.DepartmentId = null;
            department.Employees.Remove(oldSupervisor);
        }
        
        supervisor!.DepartmentId = departmentId;
        department.SupervisorId = supervisor.Id;
        department.Supervisor = supervisor;
        department.Employees.Add(supervisor);
        
        await _context.SaveChangesAsync();
        return department;
    }

    public async Task<Department> AddEmployeeToDepartmentAsync(int departmentId, int employeeId)
    {
        var employee = await _context.Employees.FindAsync(employeeId);
        var department = await _context.Departments.FindAsync(departmentId);
        
        employee!.DepartmentId = department!.Id;
        department.Employees.Add(employee);
        
        await _context.SaveChangesAsync();
        return department;
    }   

    public async Task<Department> DeleteEmployeeFromDepartmentAsync(int departmentId, int employeeId)
    {
        var employee = await _context.Employees.FindAsync(employeeId);
        var department = await _context.Departments.FindAsync(departmentId);
        
        if (department!.SupervisorId == employee!.Id)
        {
            department.SupervisorId = null;
            department.Supervisor = null;
        }
        
        department.Employees.Remove(employee);
        employee.DepartmentId = null;
        
        await _context.SaveChangesAsync();
        return department;
    }
    
    public async Task<Department> SoftDeleteDepartmentAsync(int departmentId)
    {
        var department = await _context.Departments.FindAsync(departmentId);
        department!.IsDeleted = true;
        
        await _context.SaveChangesAsync();
        return department;
    }
    
    public async Task<Department> UndeleteDepartmentAsync(int departmentId)
    {
        var department = await _context.Departments.FindAsync(departmentId);
        department!.IsDeleted = false;
        
        await _context.SaveChangesAsync();
        return department;
    }
    
}

