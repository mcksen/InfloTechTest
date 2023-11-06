
using System.Linq;
using System.Threading.Tasks;
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

    [HttpGet("delete")]
    public async Task<IActionResult> Delete(long id)
    {
        User? user = _userService.GetUser(id);
        if (user != null)
        {
            await _userService.DeleteUser(user);
            return List();
        }
        else
        {
            return View("Error");
        }

    }

    [HttpGet("add")]
    public ViewResult Add()
    {
        return View("Add");

    }
    [HttpPost("saveNewUser")]
    public async Task<IActionResult> SaveNewUser([FromForm] User user)
    {

        if (user != null)
        {
            await _userService.AddUser(user);
            return List();
        }
        else
        {
            return View("Error");
        }

    }

    private ViewResult GetViewResult(IEnumerable<User> users)
    {

        var items = users.Select(p => new UserListItemViewModel
        {

            Id = p.Id,
            Forename = p.Forename,
            Surname = p.Surname,
            Email = p.Email,
            DateOfBirth = p.DateOfBirth.ToString("dd/MM/yyyy"),
            IsActive = p.IsActive
        });

        var model = new UserListViewModel
        {
            Items = items.ToList()
        };

        return View(nameof(List), model);
    }
}
