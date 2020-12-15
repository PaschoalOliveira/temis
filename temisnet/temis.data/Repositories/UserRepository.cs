using System;
using System.Collections.Generic;
using System.Linq;
using temis.Core.Interfaces;
using temis.Core.Models;

namespace temis.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<User> users = new List<User>()
        {
            new User() 
                {
                   Id=1, 
                   Username="teste",
                   Password = "teste",
                   Idade = 45,
                   Nome = "teste",
                   Sobrenome = "teste",
                },
            new User() 
                {
                   Id=2, 
                   Username="teste",
                   Password = "teste",
                   Idade = 45,
                   Nome = "teste",
                   Sobrenome = "teste",
                },
            new User() 
                {
                   Id=3, 
                   Username="teste",
                   Password = "teste",
                   Idade = 45,
                   Nome = "teste",
                   Sobrenome = "teste",
                },
            new User() 
                {
                   Id=4, 
                   Username="teste",
                   Password = "teste",
                   Idade = 45,
                   Nome = "teste",
                   Sobrenome = "teste",
                },
            new User() 
                {
                   Id=5, 
                   Username="teste",
                   Password = "teste",
                   Idade = 45,
                   Nome = "teste",
                   Sobrenome = "teste",
                }
        };
        public List<User> FindAll()
        {
            return users;
        }

        public User FindById(long id)
        {
            User user = users.Where( u => u.Id == id).FirstOrDefault();
            return user;
        }
        public User CreateUser(User user) 
        {
            bool isExist = users.Any(userClient => userClient.Id == user.Id);

            if(user!=null && !isExist)
            {
                users.Add(user);
                return user;
            }
                return null;
        }

        public User EditUser(User user)
        {
            
            User userNew = users.Where( u => u.Id == user.Id).FirstOrDefault();

            if (userNew !=null)
            {
                userNew.Idade = user.Idade;
                userNew.Nome = user.Nome;
                userNew.Password = user.Password;
                userNew.Sobrenome = user.Sobrenome;
                userNew.Username = user.Username;
            }
            
            return user;
        }

        public void Delete(long id)
        {
            User user = FindById(id);
            users.Remove(user);
        }

        public void EditPassword(long id, string password)
        {
           User userPassword = new User() {Id = id};
           userPassword.Password = password;
        }

        public IEnumerable<User> PartialEditUser(string username)
        {
            
            IEnumerable<User> user =
            from userByName in users
            where userByName.Username == username
            select userByName;

            return user;
        }
    }
}