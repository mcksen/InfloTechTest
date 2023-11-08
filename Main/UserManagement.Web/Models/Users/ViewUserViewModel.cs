using System;
using UserManagement.Models;

namespace UserManagement.Web.Models.Users;


public class ViewUserViewModel
{
    public long Id { get; set; }
    public string? Forename { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? DateOfBirth { get; set; }
    public string? IsActive { get; set; }

    public List<Log> userLogs = new();
}