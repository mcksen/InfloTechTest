using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Models;

public interface ILogService
{
    IEnumerable<Log> GetLogs<T>();
    IEnumerable<Log> GetLogsById<T>(long id);

}