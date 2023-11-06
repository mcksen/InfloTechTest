
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;


using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;


namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService
{
    private readonly IDataContext _dataAccess;
    public UserService(IDataContext dataAccess) => _dataAccess = dataAccess;

    public IEnumerable<User> FilterByActive(bool isActive)
          => _dataAccess.GetAll<User>().Where(p => p.IsActive == isActive);


    public User? GetUser(long id) => _dataAccess.GetEntity<User>(id);
    public IEnumerable<User> GetAll() => _dataAccess.GetAll<User>();
    public async Task<int> EditUser(User user)
    {

        var result = await _dataAccess.UpdateAsync(user);
        return result;

    }
    public async Task<int> DeleteUser(User user)
    {

        var result = await _dataAccess.DeleteAsync(user);
        return result;

    }
    public async Task<int> AddUser(User user)
    {

        var result = await _dataAccess.CreateAsync(user);
        return result;

    }

}

