using System.Linq;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

[Route("user")]
public class UserController : Controller
{

    private readonly IUserService _userService;
    public UserController(IUserService userService) => _userService = userService;

    [HttpGet("view")]
    public ViewResult View(long id)
    {
        return GetViewResult(id);
    }

    private ViewResult GetViewResult(long id)
    {

        var user = _userService.GetUser(id);

        UserViewModel model = new UserViewModel

        {
            Forename = user?.Forename,
            Surname = user?.Surname,
            Email = user?.Email,
            DateOfBirth = user?.DateOfBirth.ToString("MM/dd/yyyy"),
            IsActive = user?.IsActive
        };



        return View(nameof(View), model);
    }
}