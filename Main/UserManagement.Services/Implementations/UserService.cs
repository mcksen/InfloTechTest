using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UserManagement.Data;
using UserManagement.Models;
using UserManagement.Services.Domain.Interfaces;

namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService
{
    private readonly IDataContext _dataAccess;
    public UserService(IDataContext dataAccess)
    {
        _dataAccess = dataAccess;

    }

    public event StateChangeEvent? onUserUpdated;



    public IEnumerable<User> FilterByActive(bool isActive)
          => _dataAccess.GetAll<User>().Where(p => p.IsActive == isActive);


    public User? GetUser(long id) => _dataAccess.GetEntity<User>(id);
    public IEnumerable<User> GetAll() => _dataAccess.GetAll<User>();
    public void EditUser(User user)
    {
        void TriggerUserUpdated(object? sender, SavedChangesEventArgs e)
        {
            onUserUpdated?.Invoke(user);
            _dataAccess.SavedChanges -= TriggerUserUpdated;
        }
        _dataAccess.SavedChanges += TriggerUserUpdated;
        _dataAccess.Update(user);

    }


}

