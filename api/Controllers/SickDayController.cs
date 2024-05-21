using api.Attributes;
using api.Constants;
using api.Dtos.SickDay;
using api.Mappers;
using api.Models;
using api.QueryObjects;
using api.Repository.Interfaces;
using api.Utils;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/sickdays")]
public class SickDayController : ControllerBase
{
    private readonly ISickDayRepository _sickDayRepo;
    
    public SickDayController(ISickDayRepository sickDayRepository)
    {
        _sickDayRepo = sickDayRepository;
    }
    
    [HttpPost("announcement/employee/{employeeId:int}")]
    public async Task<IActionResult> AnnounceSickDay([FromRoute, ValidEmployeeId] int employeeId, 
        [FromBody] CreateSickDayAnnouncementDto createSickDayAnnouncement)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var model = SickDayMapper.ToSickDayFromSickDayAnnouncementDto(createSickDayAnnouncement, employeeId);
        if (DateRangeValidator.IsDateWithinRange(model.StartDate, model.EndDate, 
                SickDayConstants.MinSickDayDuration, SickDayConstants.MaxSickDayDuration))
        {
            return BadRequest($"Sick day must be between {SickDayConstants.MinSickDayDuration} " +
                              $"and {SickDayConstants.MaxSickDayDuration} days.");
        }
        
        var announcedSickDay = await _sickDayRepo.AddSickDayAsync(model);
        return Ok(SickDayMapper.ToSickDayDto(announcedSickDay));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetByQuery([FromQuery] TimeOffQueryParameters queryParams)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var sickDays = await _sickDayRepo.GetSickDaysByQueryAsync(queryParams);
        return Ok(sickDays.Select(SickDayMapper.ToSickDayDto));
    }
    
}