using api.Dtos.SickDay;
using api.Models;

namespace api.Mappers;

public static class SickDayMapper
{
    public static SickDayDto ToSickDayDto(SickDay sickDayModel)
    {
        return new SickDayDto
        {
            RequestDate = sickDayModel.RequestDate,
            StartDate = sickDayModel.StartDate,
            EndDate = sickDayModel.EndDate,
            EmployeeId = sickDayModel.EmployeeId,
            Message = sickDayModel.Message
        };
    }
    
    public static SickDay ToSickDayFromSickDayAnnouncementDto(CreateSickDayAnnouncementDto createSickDayAnnouncementDto, int employeeId)
    {
        return new SickDay
        {
            RequestDate = DateTime.Now,
            StartDate = DateOnly.ParseExact(createSickDayAnnouncementDto.StartDate, "dd.MM.yyyy", null),
            EndDate = DateOnly.ParseExact(createSickDayAnnouncementDto.EndDate, "dd.MM.yyyy", null),
            EmployeeId = employeeId,
            Message = createSickDayAnnouncementDto.Message
        };
    }
}