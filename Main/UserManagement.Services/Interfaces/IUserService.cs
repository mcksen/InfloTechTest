using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Models;


namespace UserManagement.Services.Domain.Interfaces;

public delegate void StateChangeEvent(User user);

public interface IUserService
{

    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    IEnumerable<User> FilterByActive(bool isActive);
    User? GetUser(long id);
    Task<int> EditUser(User user);
    IEnumerable<User> GetAll();
}
