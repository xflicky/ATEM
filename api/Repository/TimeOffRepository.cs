using api.Data;
using api.Models;
using api.QueryObjects;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class TimeOffRepository : ITimeOffRepository
{
    
    private readonly ApplicationDbContext _context;
    
    public TimeOffRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TimeOff> GetTimeOffByIdAsync(int timeOffId)
    {
        return await _context.TimeOffs
            .Where(t => t.Id == timeOffId)
            .FirstAsync();    
    }
    
    public async Task<TimeOff> AddTimeOffAsync(TimeOff timeOffModel)
    {
        await _context.TimeOffs.AddAsync(timeOffModel);
        await _context.SaveChangesAsync();
        return timeOffModel;
    }
    
    public async Task<List<TimeOff>> GetAllTimeOffsAsync()
    {
        return await _context.TimeOffs.ToListAsync();
    }
    
    public async Task<List<TimeOff>> GetTimeOffByQueryAsync(TimeOffQueryParameters queryParams)
    {
        var baseQuery = _context.TimeOffs.AsQueryable();
        if (queryParams.EmployeeId.HasValue)
        {
            baseQuery = baseQuery.Where(t => t.EmployeeId == queryParams.EmployeeId);
        }
        
        if (!queryParams.Month.HasValue && queryParams.Year.HasValue)
        {
            return await baseQuery
                .Where(t => t.StartDate.Year == queryParams.Year)
                .ToListAsync();
        }
        
        if (queryParams.Month.HasValue && queryParams.Year.HasValue)
        {
            return await baseQuery
                .Where(t => t.StartDate.Month == queryParams.Month
                            && t.StartDate.Year == queryParams.Year)
                .ToListAsync();
        }
        
        return await baseQuery.ToListAsync();
    }
    
    public async  Task<List<TimeOff>> GetTimeOffByDateAsync(int month, int year)
    {
        return await _context.TimeOffs
            .Where(t => t.StartDate.Month == month
                        && t.StartDate.Year == year)
            .ToListAsync();
    }
    
    public async Task<TimeOff> ApproveTimeOffAsync(int timeOffId)
    {
        var timeOff = await _context.TimeOffs
            .Where(t => t.Id == timeOffId)
            .FirstAsync();
        
        timeOff.Approved = true;
        await _context.SaveChangesAsync();
        return timeOff;
    }
    
}
