using api.Models;
using api.QueryObjects;

namespace api.Repository.Interfaces;

public interface IAttendanceRecordRepository
{
    Task<AttendanceRecord> CreateAttendanceRecordAsync(AttendanceRecord attendanceRecord);
    Task<List<AttendanceRecord>> GetAllAttendanceRecordsByQueryAsync(TimeSheetQueryParameters queryParams);
    
}