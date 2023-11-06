using System;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;
using UserManagement.Web.Models.Users;

namespace UserManagement.WebMS.Controllers;

[Route("user")]
public class UserController : Controller
{

    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;

    }


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

        }
        return View(nameof(View), model);
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
        }

        return View(nameof(Edit), model);
    }

    [HttpPost("save")]
    public async Task<IActionResult> HandleSaveButtonClick([FromForm] User user)
    {
        User userToUpdate = new User();
        userToUpdate.Id = user.Id;
        userToUpdate.Forename = user.Forename;
        userToUpdate.Surname = user.Surname;
        userToUpdate.Email = user.Email;
        userToUpdate.DateOfBirth = user.DateOfBirth;
        userToUpdate.IsActive = user.IsActive;

        await _userService.EditUser(user);

        return View(user.Id);
    }


}