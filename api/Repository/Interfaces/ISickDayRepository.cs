using api.Models;
using api.QueryObjects;

namespace api.Repository.Interfaces;

public interface ISickDayRepository
{
    Task<SickDay> AddSickDayAsync(SickDay sickDayModel);
    Task<List<SickDay>> GetAllSickDaysAsync();
    
    Task<List<SickDay>> GetSickDaysByQueryAsync(TimeOffQueryParameters queryParams);
}