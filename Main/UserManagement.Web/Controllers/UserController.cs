using System.Threading.Tasks;
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
        var user = _userService.GetUser(id);

        ViewUserViewModel model = new ViewUserViewModel();
        if (user != null)
        {
            model.Id = id;
            model.Forename = user.Forename;
            model.Surname = user.Surname;
            model.Email = user.Email;
            model.DateOfBirth = user.DateOfBirth.ToString("dd/MM/yyyy");
            model.IsActive = user.IsActive ? "Yes" : "No";
            return View(nameof(View), model);
        }
        else
        {
            return View("Error");
        }

    }


    [HttpGet("edit")]
    public ViewResult Edit(long id)
    {
        var user = _userService.GetUser(id);
        EditUserViewModel model = new EditUserViewModel();
        if (user != null)
        {
            model.Id = id;
            model.Forename = user.Forename;
            model.Surname = user.Surname;
            model.Email = user.Email;
            model.DateOfBirth = user.DateOfBirth;
            model.IsActive = user.IsActive;
            return View(nameof(Edit), model);
        }
        else
        {
            return View("Error");
        }


    }

    [HttpPost("saveEdit")]
    public async Task<IActionResult> SaveEdit([FromForm] User user)
    {

        if (user != null)
        {
            await _userService.EditUser(user);
            return View(user.Id);
        }
        else
        {
            return View("Error");
        }

    }


}