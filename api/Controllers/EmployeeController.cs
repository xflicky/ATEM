using System.ComponentModel.DataAnnotations;
using api.Attributes;
using api.Data;
using api.Dtos.Employee;
using api.Mappers;
using api.QueryObjects;
using api.Repository;
using api.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _repo;

    public EmployeeController(IEmployeeRepository repository)
    {
        _repo = repository;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeRequestDto employeeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        await _repo.CreateEmployeeAsync(EmployeeMapper.ToEmployeeFromCreateDto(employeeDto));
        return Ok(employeeDto);
    } 

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] EmployeeQueryParameters queryParams)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var employees = await _repo.GetEmployeeByQueryAsync(queryParams);
        return Ok(EmployeeMapper.ToEmployeeDto(employees));
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAll([FromQuery] ActivityQueryParameter activityQueryParameter)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var employees = await _repo.GetAllEmployeesAsync(activityQueryParameter);
        return Ok(employees.Select(EmployeeMapper.ToEmployeeDto));
    }
    
    [HttpPut("{employeeId:int}")]
    public async Task<IActionResult> Update([FromRoute, ValidEmployeeId] int employeeId, [FromBody] UpdateEmployeeRequestDto employeeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var employee = await _repo.UpdateEmployeeAsync(EmployeeMapper.ToEmployeeFromUpdateDto(employeeDto), employeeId);
        return Ok(EmployeeMapper.ToEmployeeDto(employee!));
    }
    
    [HttpPost("{employeeId:int}/soft-delete")]
    public async Task<IActionResult> SoftDeleteEmployee([FromRoute, ValidEmployeeId] int employeeId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var employee = await _repo.SoftDeleteEmployeeAsync(employeeId);
        return Ok(employee);
    }
    
    [HttpPost("{employeeId:int}/undelete")]
    public async Task<IActionResult> UndeleteEmployee([FromRoute, ValidEmployeeId] int employeeId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var employee = await _repo.UndeleteEmployeeAsync(employeeId);
        return Ok(employee);
    }
    
}