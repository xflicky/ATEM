using api.Models;
using api.QueryObjects;

namespace api.Repository.Interfaces;

public interface ITimeOffRepository
{
    Task<TimeOff> AddTimeOffAsync(TimeOff timeOffModel);
    Task<TimeOff> GetTimeOffByIdAsync(int timeOffId);
    Task<TimeOff> ApproveTimeOffAsync(int timeOffId);
    Task<List<TimeOff>> GetTimeOffByQueryAsync(TimeOffQueryParameters queryParams);
}