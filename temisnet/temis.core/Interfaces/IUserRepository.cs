using System.Collections.Generic;
using temis.Core.Models;

namespace temis.Core.Interfaces
{
    public interface IUserRepository
    {
         User CreateUser(User user);
         User EditUser(User user);
         List<User> FindAll();
         User FindById(long id);
         IEnumerable<User> PartialEditUser(string username);
         void EditPassword(long id, string password);
         void Delete(long Id);
    }
}