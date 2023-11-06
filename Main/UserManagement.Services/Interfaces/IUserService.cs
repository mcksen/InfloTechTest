using System.Collections.Generic;
using UserManagement.Models;


namespace UserManagement.Services.Domain.Interfaces;

public delegate void StateChangeEvent(User user);

public interface IUserService
{
    event StateChangeEvent? onUserUpdated;
    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    IEnumerable<User> FilterByActive(bool isActive);
    User? GetUser(long id);
    void EditUser(User user);
    IEnumerable<User> GetAll();
}
