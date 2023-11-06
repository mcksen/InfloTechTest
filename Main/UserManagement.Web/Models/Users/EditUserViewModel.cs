using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Web.Models.Users;


public class EditUserViewModel
{
    public long Id { get; set; }
    public string? Forename { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsActive { get; set; }
}