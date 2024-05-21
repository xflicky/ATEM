using System.Reflection;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using api.Dtos.AttendanceRecord;

namespace api.Serializers;

public static class CsvSerializer
{
    private static readonly string _rootPath = 
         Path.Combine(Directory.GetCurrentDirectory(), "TimeSheetsExports");
    
    public static string SerializeTimeSheet(AttendanceTimeSheetDto timeSheet)
    {
        var path = Path.Combine(_rootPath, 
            $"{timeSheet.EmployeeName}_{timeSheet.EmployeeSurName}_{timeSheet.MonthPeriod}_{timeSheet.YearPeriod}_timesheet.csv");
        
        WriteCsvToFile(BuildCsvTimeSheet(timeSheet), path);
        return path;
    }

    private static string BuildCsvTimeSheet(AttendanceTimeSheetDto timeSheet)
    {
        var sb = new StringBuilder();
        sb.AppendLine("EmployeeId,EmployeeName,EmployeeSurName,MonthPeriod,YearPeriod");
        sb.AppendLine($"{timeSheet.EmployeeId},{timeSheet.EmployeeName},{timeSheet.EmployeeSurName},{timeSheet.MonthPeriod},{timeSheet.YearPeriod}");
        sb.AppendLine();
        sb.AppendLine("Date,TimeIn,TimeOut,TotalHours");

        for (var i = 0; i < timeSheet.AttendanceRecords.Count; i+=1)
        {
            if (i % 2 == 1)
            {
                var recordIn = timeSheet.AttendanceRecords[i -1];
                var recordOut = timeSheet.AttendanceRecords[i];
                sb.AppendLine($"{recordIn.EvidenceDate.Date}," +
                              $"{recordIn.EvidenceDate.TimeOfDay}," +
                              $"{recordOut.EvidenceDate.TimeOfDay}," +
                              $"{recordOut.EvidenceDate.TimeOfDay - recordIn.EvidenceDate.TimeOfDay}");
            }
        }
        
        if (timeSheet.AttendanceRecords.Count % 2 != 0)
        {
            var record = timeSheet.AttendanceRecords[^1];
            sb.AppendLine($"{record.EvidenceDate.Date}," +
                          $"{record.EvidenceDate.TimeOfDay}," +
                          "No Exit," +
                          "No Total");
        }
        
        return sb.ToString();
    }
    
    private static void WriteCsvToFile(string csv, string filePath)
    {
        if (!Directory.Exists(_rootPath))
        {
            Directory.CreateDirectory(_rootPath);
        }
        
        File.WriteAllText(filePath, csv);
    }
    
}
