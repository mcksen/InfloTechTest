using System.Linq;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

[Route("users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService) => _userService = userService;

    [HttpGet("list")]
    public ViewResult List()
    {
        return GetViewResult(_userService.GetAll());
    }

    [HttpGet("active")]
    public ViewResult ActiveUsersList()
    {
        return GetViewResult(_userService.FilterByActive(true));
    }

    [HttpGet("inactive")]
    public ViewResult InactiveUsersList()
    {
        return GetViewResult(_userService.FilterByActive(false));
    }



    private ViewResult GetViewResult(IEnumerable<User> users)
    {

        var items = users.Select(p => new UserListItemViewModel
        {

            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            DateOfBirth = p.DateOfBirth.ToString("MM/dd/yyyy"),
            IsActive = p.IsActive
        });

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        return View(nameof(List), model);
    }
}
