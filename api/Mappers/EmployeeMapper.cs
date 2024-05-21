using api.Dtos.Employee;
using api.Models;

namespace api.Mappers;

public static class EmployeeMapper
{
    public static EmployeeDto ToEmployeeDto(Employee employeeModel)
    {
        return new EmployeeDto
        {
            Id = employeeModel.Id,
            DepartmentId = employeeModel.DepartmentId,
            Name = employeeModel.Name,
            SurName = employeeModel.SurName,
            BirthDate = employeeModel.BirthDate,
            Address = employeeModel.Address,
            Email = employeeModel.Email,
            Phone = employeeModel.Phone,
            IsPresent = employeeModel.IsPresent
        };
    }

    public static Employee ToEmployeeFromCreateDto(CreateEmployeeRequestDto employeeDto)
    {
        return new Employee
        {
            RegistrationDate = DateTime.Now,
            
            Name = employeeDto.Name,
            SurName = employeeDto.SurName,
            BirthDate = DateOnly.ParseExact(employeeDto.BirthDate, "dd.MM.yyyy", null),
            Address = employeeDto.Address,
            Email = employeeDto.Email,
            Phone = employeeDto.Phone
        };
    }
    
    public static Employee ToEmployeeFromUpdateDto(UpdateEmployeeRequestDto employeeDto)
    {
        return new Employee
        {
            Name = employeeDto.Name,
            SurName = employeeDto.SurName,
            Address = employeeDto.Address,
            Email = employeeDto.Email,
            Phone = employeeDto.Phone
        };
    }
    
    
}