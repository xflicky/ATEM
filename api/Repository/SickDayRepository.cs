using api.Data;
using api.Models;
using api.QueryObjects;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class SickDayRepository : ISickDayRepository
{
    private readonly ApplicationDbContext _context;

    public SickDayRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    

    public async Task<SickDay> AddSickDayAsync(SickDay sickDayModel)
    {
        await _context.SickDays.AddAsync(sickDayModel);
        await _context.SaveChangesAsync();
        return sickDayModel;
    }
    
    public Task<List<SickDay>> GetAllSickDaysAsync()
    {
        return _context.SickDays.ToListAsync();
    }

    public Task<List<SickDay>> GetSickDaysByQueryAsync(TimeOffQueryParameters queryParams)
    {
        var baseQuery = _context.SickDays.AsQueryable();
        if (queryParams.EmployeeId.HasValue)
        {
            baseQuery = baseQuery.Where(s => s.EmployeeId == queryParams.EmployeeId);
        }
        
        if (!queryParams.Month.HasValue && queryParams.Year.HasValue)
        {
            return baseQuery.Where(s => s.StartDate.Year == queryParams.Year).ToListAsync();
        }
        
        if (queryParams.Month.HasValue && queryParams.Year.HasValue)
        {
            return baseQuery.Where(s => s.StartDate.Month == queryParams.Month && s.StartDate.Year == queryParams.Year).ToListAsync();
        }
        
        return baseQuery.ToListAsync();
    }
}