using System;
using System.Collections.Generic;
using System.Linq;


using UserManagement.Data;
using UserManagement.Models;

public class LogService : ILogService
{
    private readonly IDataContext _context;

    public LogService(IDataContext context) => _context = context;

    public IEnumerable<Log> GetLogs<T>() => _context.GetAll<Log>().Where(x => x.EntityType == (typeof(T).Name));
    public IEnumerable<Log> GetLogsById<T>(long id) => GetLogs<T>().Where(x => x.EntityId == id);
    public IEnumerable<Log> FilterByDate(DateTime min, DateTime max) => _context.GetAll<Log>().Where(p => p.Timestamp <= max && p.Timestamp >= min);

}
