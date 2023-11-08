using System;
using System.Collections.Generic;
using UserManagement.Models;

public interface ILogService
{
    IEnumerable<Log> GetLogs<T>();
    IEnumerable<Log> GetLogsById<T>(long id);
    IEnumerable<Log> FilterByDate(DateTime min, DateTime max);

}