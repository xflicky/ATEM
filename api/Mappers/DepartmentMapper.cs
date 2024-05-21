using api.Dtos.Department;
using api.Models;

namespace api.Mappers;

public static class DepartmentMapper
{
    public static DepartmentDto ToDepartmentDto(Department departmentModel)
    {
        return new DepartmentDto
        {
            Id = departmentModel.Id,
            Name = departmentModel.Name,
            SupervisorId = departmentModel.SupervisorId,
            
            Employees = departmentModel.Employees
                .Where(employee => !employee.IsDeleted)
                .Select(employee => EmployeeMapper.ToEmployeeDto(employee))
                .ToList()
        };
    }
    
    public static Department ToDepartmentFromCreateDto(CreateDepartmentRequestDto departmentDto)
    {
        return new Department
        {
            RegistrationDate = DateTime.Now,
            Name = departmentDto.Name
        };
    }
}