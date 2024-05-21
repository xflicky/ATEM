using api.Data;
using api.Mappers;
using api.Models;
using api.QueryObjects;
using api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class AttendanceRecordRepository : IAttendanceRecordRepository
{

    private readonly ApplicationDbContext _dbContext;

    public AttendanceRecordRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<AttendanceRecord> CreateAttendanceRecordAsync(AttendanceRecord attendanceRecord)
    {
        await _dbContext.AttendanceRecords.AddAsync(attendanceRecord);
        await _dbContext.SaveChangesAsync();
        return attendanceRecord;
    }

    public async Task<List<AttendanceRecord>> GetAllAttendanceRecordsByEmployeeAsync(Employee employee)
    {
        return await _dbContext.AttendanceRecords
            .Where(ar => ar.EmployeeId == employee.Id)
            .ToListAsync();
    }

    public async Task<List<AttendanceRecord>> GetAllAttendanceRecordsByQueryAsync(TimeSheetQueryParameters queryParams)
    {
        return await _dbContext.AttendanceRecords
            .Where(ar => ar.EmployeeId == queryParams.EmployeeId
                         && ar.EvidenceDate.Month >= queryParams.Month
                         && ar.EvidenceDate.Year <= queryParams.Year)
            .ToListAsync();
    }

}