using System.Collections.Generic;
using temis.Core.Models;

namespace temis.Core.Services.Interfaces
{
    public interface IUserService
    {
         User CreateUser(User user);
         User EditUser(User user);
         List<User> FindAll();
         User FindById(long id);
         void EditPassword(long id, string password);
         void Delete(long Id);
         PageResponse<User> Filter (string name, PageRequest pageRequest);
    }
}