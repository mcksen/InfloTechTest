using System;

namespace UserManagement.Web.Models.Users;


public class UserViewModel
{

    public string? Forename { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? DateOfBirth { get; set; }
    public bool? IsActive { get; set; }
}