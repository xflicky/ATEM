using api.Models;
using api.QueryObjects;

namespace api.Repository.Interfaces;

public interface IDepartmentRepository
{
    Task<List<Department>> GetAllDepartmentsAsync(ActivityQueryParameter activityQueryParameter);
    Task<Department> GetDepartmentByIdAsync(int id);
    Task<Department> GetDepartmentInactiveByIdAsync(int id);
    Task<Department> CreateDepartmentAsync(Department department);
    Task<Department> SetSupervisorToDepartmentAsync(int departmentId, int employeeId);
    Task<Department> AddEmployeeToDepartmentAsync(int departmentId, int employeeId);
    Task<Department> DeleteEmployeeFromDepartmentAsync(int departmentId, int employeeId);
    Task<Department> SoftDeleteDepartmentAsync(int departmentId);
    Task<Department> UndeleteDepartmentAsync(int departmentId);
    
}