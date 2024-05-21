using api.Attributes;
using api.Data;
using api.Dtos.AttendanceRecord;
using api.Mappers;
using api.Models;
using api.QueryObjects;
using api.Repository.Interfaces;
using api.Serializers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Route("api/attendance")]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceRecordRepository _attendanceRepo;
    private readonly IEmployeeRepository _employeeRepo;
    
    public AttendanceController(IAttendanceRecordRepository attendanceRecordRepository, IEmployeeRepository employeeRepository)
    {
        _attendanceRepo = attendanceRecordRepository;
        _employeeRepo = employeeRepository;
    }
    
    [HttpPost("record/employee/{employeeId:int}")]
    public async Task<IActionResult> Record([FromRoute, ValidEmployeeId] int employeeId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var employee = await _employeeRepo.GetEmployeeByIdAsync(employeeId);
        var record = await _attendanceRepo.CreateAttendanceRecordAsync(
            AttendanceRecordMapper.ToAttendanceRecordFromCreateRequest(employee));
        
        return Ok(AttendanceRecordMapper.ToAttendanceRecordDto(record));
    }
    
    [HttpGet("timesheet")]
    public async Task<IActionResult> GetAll([FromQuery] TimeSheetQueryParameters queryParams)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var records = await _attendanceRepo.GetAllAttendanceRecordsByQueryAsync(queryParams);
        var employee = await _employeeRepo.GetEmployeeByIdAsync(queryParams.EmployeeId);
        return Ok(AttendanceRecordMapper.ToTimeSheetDto(employee, records, queryParams.Month, queryParams.Year));
    }
    
    [HttpGet("timesheet-download/")]
    public async Task<IActionResult> DownloadTimesheet([FromQuery] TimeSheetQueryParameters queryParams)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var records = await _attendanceRepo.GetAllAttendanceRecordsByQueryAsync(queryParams);
        var employee = await _employeeRepo.GetEmployeeByIdAsync(queryParams.EmployeeId);
        
        var timeSheet = AttendanceRecordMapper.ToTimeSheetDto(employee, records, queryParams.Month, queryParams.Year);
        var filePath = CsvSerializer.SerializeTimeSheet(timeSheet);
        return PhysicalFile(filePath, "text/csv", Path.GetFileName(filePath));
    }
    
}