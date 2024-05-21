using api.Attributes;
using api.Data;
using api.Dtos.Department;
using api.Mappers;
using api.QueryObjects;
using api.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;


[Route("api/departments")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentRepository _departmentRepo;
    private readonly IEmployeeRepository _employeeRepo;
    
    public DepartmentController(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository)
    {
        _departmentRepo = departmentRepository;
        _employeeRepo = employeeRepository;
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAll([FromQuery] ActivityQueryParameter activityQueryParameter)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var departments = await _departmentRepo.GetAllDepartmentsAsync(activityQueryParameter);
        return Ok(departments.Select(DepartmentMapper.ToDepartmentDto));
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateDepartmentRequestDto departmentDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var department = DepartmentMapper.ToDepartmentFromCreateDto(departmentDto);
        await _departmentRepo.CreateDepartmentAsync(department);
        
        return Ok(departmentDto);
    }
    
    [HttpGet("{departmentId:int}")]
    public async Task<IActionResult> GetById([FromRoute, ValidDepartmentId] int departmentId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var department = await _departmentRepo.GetDepartmentByIdAsync(departmentId);
        return Ok(DepartmentMapper.ToDepartmentDto(department));
    }

    [HttpPost("{departmentId:int}/soft-delete")]
    public async Task<IActionResult> SoftDelete([FromRoute, ValidDepartmentId] int departmentId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var department = await _departmentRepo.SoftDeleteDepartmentAsync(departmentId);
        return Ok(department);
    }
    
    [HttpPost("{departmentId:int}/undelete")]
    public async Task<IActionResult> Undelete([FromRoute, ValidDepartmentId] int departmentId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var department = await _departmentRepo.UndeleteDepartmentAsync(departmentId);
        return Ok(DepartmentMapper.ToDepartmentDto(department));
    }
    
    [HttpPatch("{departmentId:int}/set-supervisor/{employeeId}")]
    public async Task<IActionResult> SetSupervisor([FromRoute, ValidDepartmentId] int departmentId, [FromRoute, ValidEmployeeId] int employeeId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var department = await _departmentRepo.SetSupervisorToDepartmentAsync(departmentId, employeeId);
        return Ok(DepartmentMapper.ToDepartmentDto(department));
    }
    
    [HttpPost("{departmentId:int}/add-employee/{employeeId:int}")]
    public async Task<IActionResult> AddEmployee([FromRoute, ValidDepartmentId] int departmentId, [FromRoute, ValidEmployeeId] int employeeId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var employee = await _departmentRepo.AddEmployeeToDepartmentAsync(departmentId, employeeId);
        return Ok(DepartmentMapper.ToDepartmentDto(employee));
    }
    
    [HttpDelete("{departmentId:int}/delete-employee/{employeeId:int}")]
    public async Task<IActionResult> RemoveEmployee([FromRoute, ValidDepartmentId] int departmentId, [FromRoute, ValidEmployeeId] int employeeId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var department = await _departmentRepo.DeleteEmployeeFromDepartmentAsync(departmentId, employeeId);
        return Ok(DepartmentMapper.ToDepartmentDto(department));
    }
    
}