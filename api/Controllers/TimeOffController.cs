using api.Attributes;
using api.Constants;
using api.Dtos.TimeOff;
using api.Mappers;
using api.Models;
using api.QueryObjects;
using api.Repository.Interfaces;
using api.Utils;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/timeoffs")]
public class TimeOffController : ControllerBase
{
    private readonly ITimeOffRepository _timeOffRepo;
    
    public TimeOffController(ITimeOffRepository timeOffRepository)
    {
        _timeOffRepo = timeOffRepository;
    }

    [HttpPost("request/employee/{employeeId:int}")]
    public async Task<IActionResult> RequestTimeOff([FromBody] CreateTimeOffRequestDto createTimeOff, [FromRoute, ValidEmployeeId] int employeeId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var model = TimeOffMapper.ToTimeOffFromTimeOffRequestDto(createTimeOff, employeeId);
        if (DateRangeValidator.IsDateWithinRange(model.StartDate, model.EndDate, 
                TimeOffConstants.MinTimeOffDuration, TimeOffConstants.MaxTimeOffDuration))
        {
            return BadRequest($"Time off must be at least {TimeOffConstants.MinTimeOffDuration} " +
                              $"and max {TimeOffConstants.MaxTimeOffDuration} days.");
        }
        
        var requestedTimeOff = await _timeOffRepo.AddTimeOffAsync(model);
        return Ok(TimeOffMapper.ToTimeOffDto(requestedTimeOff));
    }
    
    [HttpGet("{timeOffId:int}")]
    public async Task<IActionResult> GetById([FromRoute, ValidTimeOffId] int timeOffId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var timeOff = await _timeOffRepo.GetTimeOffByIdAsync(timeOffId);
        return Ok(TimeOffMapper.ToTimeOffDto(timeOff));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllByQuery([FromQuery] TimeOffQueryParameters queryParams)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var timeOffs = await _timeOffRepo.GetTimeOffByQueryAsync(queryParams);
        return Ok(timeOffs.Select(TimeOffMapper.ToTimeOffDto));
    }
    
    [HttpPost("approve/{timeOffId:int}")]
    public async Task<IActionResult> ApproveTimeOff([FromRoute, ValidTimeOffId] int timeOffId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var timeOff = await _timeOffRepo.ApproveTimeOffAsync(timeOffId);
        return Ok(TimeOffMapper.ToTimeOffDto(timeOff));
    }
    
}