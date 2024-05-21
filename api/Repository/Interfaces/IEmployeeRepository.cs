using api.Models;
using api.QueryObjects;

namespace api.Repository.Interfaces;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllEmployeesAsync(ActivityQueryParameter activityQueryParameter);
    Task<Employee> GetEmployeeByIdAsync(int id);
    Task<Employee> GetEmployeeByQueryAsync(EmployeeQueryParameters queryParams);
    Task<Employee> CreateEmployeeAsync(Employee employee);
    Task<Employee> UpdateEmployeeAsync(Employee employee, int id);
    Task<Employee> SoftDeleteEmployeeAsync(int id);
    Task<Employee> UndeleteEmployeeAsync(int id);
}