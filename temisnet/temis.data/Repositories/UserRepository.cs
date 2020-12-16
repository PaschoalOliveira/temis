using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using temis.Core.Interfaces;
using temis.Core.Models;
using temis.data.Data;

namespace temis.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MembroContext context;
        private DbSet<User> dataset;

        public UserRepository(MembroContext ctx)
        {
            context = ctx;
            dataset = context.Set<User>();
        }
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
            var membros = dataset.FromSqlRaw("Select * From member_tbl").ToList();
            return membros.OrderBy(u => u.Nome).ToList();
        }

        public User FindById(long id)
        { 
            User user = context.Membros.FromSqlRaw("Select * From member_tbl").Where((p) => p.Id == id).FirstOrDefault();
        //   User user = context.Membros.FromSqlRaw($"Select * From member_tbl Where MembrosId = {0}",id).FirstOrDefault();
            return user;
        //   return context.Membros.Where((p) => p.Id == id).SingleOrDefault();
        }
        public User CreateUser(User user) 
        {

            /*
                bool isExist = users.Any(userClient => userClient.Id == user.Id);

                if(user!=null && !isExist)
                {
                    // context.Membros.Add(user);
                    // context.SaveChanges();
                    context.Membros.FromSqlRaw(@"INSERT INTO member_tbl (username, password, idade, nome, sobrenome)VALUES (""value1"", ""value2"", 25, ""oi"", ""xau"");").ToList();
                    //var membros = context.Membros.FromSqlRaw("Select * From member_tbl").ToList();

                    users.Add(user);
                    return user;
                }
            */
            Exception exception = null;
            
            try
            {
                context.Membros.FromSqlRaw(@"INSERT INTO member_tbl (username, password, idade, nome, sobrenome)
                                            VALUES (""value2"", ""value2"", 25, ""oi"", ""xau"");").ToList();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            return context.Membros.FromSqlRaw("Select * From member_tbl").Where((p) => p.Username == "value2").FirstOrDefault();
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

        public PageResponse<User> Filter (long id, PageRequest pageRequest)
        {

            IQueryable<User> query = context.Membros.Where(i => i.Id == id);
            List<User> filtredUser;

           // filtredUser = 

            //return PageResponse<User>.For(filtredUser, pageRequest, query.Count());

            return null;
        }

    }
}