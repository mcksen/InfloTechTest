using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Logs;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

[Route("userlogs")]
public class UserLogsController : Controller
{


    private readonly ILogService _logService;
    public UserLogsController(ILogService logService) => _logService = logService;


    [HttpGet("list")]
    public ViewResult List()
    {
        return GetViewResult(_logService.GetLogs<User>());
    }


    private ViewResult GetViewResult(IEnumerable<Log> logs)
    {

        var items = logs.Select(p => new LogsItemViewModel
        {
            Id = p.Id,
            EntityId = p.EntityId,
            EntityType = p.EntityType,
            ActionType = (LogsItemViewModel.actionType)p.ActionType,
            Timestamp = p.Timestamp,
            Message = p.Message,
        });

        var model = new LogsViewModel

        {
            Items = items.ToList()
        };

        return View(nameof(List), model);
    }
}






