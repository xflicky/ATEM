using api.Data;
using api.Dtos.AttendanceRecord;
using api.Models;

namespace api.Mappers;

public static class AttendanceRecordMapper
{
    public static AttendanceRecordDto ToAttendanceRecordDto(AttendanceRecord attendanceRecordModel)
    {
        return new AttendanceRecordDto
        {
            Id = attendanceRecordModel.Id,
            EvidenceDate = attendanceRecordModel.EvidenceDate,
            Type = attendanceRecordModel.Type,
            EmployeeId = attendanceRecordModel.EmployeeId
        };
    }
    
    public static AttendanceRecord ToAttendanceRecordFromCreateRequest(Employee employee)
    {
        var type = employee.IsPresent ? "Exit" : "Entrance";
        employee.IsPresent = !employee.IsPresent;
        
        return new AttendanceRecord
        {
            EvidenceDate = DateTime.Now,
            Type = type,
            EmployeeId = employee.Id
        };
    }
    
    public static AttendanceTimeSheetDto ToTimeSheetDto(Employee employee, List<AttendanceRecord> attendanceRecords, int month, int year)
    {
        return new AttendanceTimeSheetDto
        {
            EmployeeId = employee.Id,
            EmployeeName = employee.Name,
            EmployeeSurName = employee.SurName,
            MonthPeriod = month,
            YearPeriod = year,
            AttendanceRecords = attendanceRecords
                .Where(ar => ar.EvidenceDate.Month == month && ar.EvidenceDate.Year == year)
                .Select(ToAttendanceRecordDto)
                .ToList()
        };
    }
    
}

