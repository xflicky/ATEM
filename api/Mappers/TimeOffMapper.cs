using api.Dtos.TimeOff;
using api.Models;

namespace api.Mappers;

public static class TimeOffMapper
{
    public static TimeOffDto ToTimeOffDto(TimeOff timeOffModel)
    {
        return new TimeOffDto
        {
            Id = timeOffModel.Id,
            RequestDate = timeOffModel.RequestDate,
            StartDate = timeOffModel.StartDate,
            EndDate = timeOffModel.EndDate,
            Reason = timeOffModel.Reason,
            Approved = timeOffModel.Approved,
            EmployeeId = timeOffModel.EmployeeId
        };
    }
    
    public static TimeOff ToTimeOffFromTimeOffRequestDto(CreateTimeOffRequestDto createTimeOffRequestDto, int employeeId)
    {
        return new TimeOff
        {
            RequestDate = DateTime.Now,
            StartDate = DateOnly.ParseExact(createTimeOffRequestDto.StartDate, "dd.MM.yyyy", null),
            EndDate = DateOnly.ParseExact(createTimeOffRequestDto.EndDate, "dd.MM.yyyy", null),
            EmployeeId = employeeId,
            Reason = createTimeOffRequestDto.Reason,
            Approved = false
        };
    }

}