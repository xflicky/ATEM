using api.Data;
using api.Models;
using api.QueryObjects;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Employee>> GetAllEmployeesAsync(ActivityQueryParameter activityQueryParameter)
    {
        if (activityQueryParameter.Active)
        {
            return await _context.Employees
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }
        
        return await _context.Employees
            .Where(e => e.IsDeleted)
            .ToListAsync();
    }
    
    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        return await _context.Employees
            .Where(e => !e.IsDeleted && e.Id == id)
            .FirstAsync();
    }

    public Task<Employee> GetEmployeeByQueryAsync(EmployeeQueryParameters queryParams)
    {
        var baseQuery = _context.Employees.AsQueryable();
        if (queryParams.Active)
        {
            baseQuery = baseQuery.Where(e => !e.IsDeleted);
        }
        
        return baseQuery
            .Where(e => e.Id == queryParams.EmployeeId)
            .FirstAsync();
    }

    public async Task<Employee> CreateEmployeeAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> UpdateEmployeeAsync(Employee employee, int id)
    {
        var existingEmployee = await _context.Employees
            .FirstAsync(e => e.Id == id);
        
        existingEmployee.Name = employee.Name;
        existingEmployee.SurName = employee.SurName;
        existingEmployee.Address = employee.Address;
        existingEmployee.Email = employee.Email;
        existingEmployee.Phone = employee.Phone;
        existingEmployee.DepartmentId = employee.DepartmentId;
        existingEmployee.IsPresent = employee.IsPresent;
        
        await _context.SaveChangesAsync();
        return existingEmployee;
    }

    public async Task<Employee> SoftDeleteEmployeeAsync(int id)
    {
        var employee = await _context.Employees
            .FirstAsync(e => e.Id == id);
        
        employee.IsDeleted = true;
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee> UndeleteEmployeeAsync(int id)
    {
        var employee = await _context.Employees
            .FirstAsync(e => e.Id == id);

        employee.IsDeleted = false;
        await _context.SaveChangesAsync();
        return employee;
    }
}