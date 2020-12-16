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
        private static List<User> users = new List<User>();
        public List<User> FindAll()
        {
            var membros = context.Membros.ToList();
            return membros.OrderBy(u => u.Nome).ToList();
        }

        public User FindById(long id)
        {
            User user = context.Membros.Where(p => p.Id == id).FirstOrDefault();
            return user;
        }
        public User CreateUser(User user)
        {
            if (user != null)
            {
                context.Database.ExecuteSqlRaw($@"INSERT INTO member_tbl (username, password, idade, nome, sobrenome)
                                            VALUES (""{user.Username}"", ""{user.Password}"", {user.Idade}, ""{user.Nome}"", ""{user.Sobrenome}"");");
            }

            return context.Membros.Where(p => p.Username == user.Username).FirstOrDefault();
        }

        public User EditUser(User user)
        {

            //User userNew = users.Where( u => u.Id == user.Id).FirstOrDefault();
            User userNew = FindById(user.Id);
            if (userNew != null)
            {
                userNew.Idade = user.Idade;
                userNew.Nome = user.Nome;
                userNew.Password = user.Password;
                userNew.Sobrenome = user.Sobrenome;
                userNew.Username = user.Username;

                //context.Membros.FromSqlRaw("INSERT ");
            }

            return user;
        }

        public void Delete(long id)
        {
            User user = FindById(id);
            context.Membros.Remove(user);
            context.SaveChanges();
        }

        public void EditPassword(long id, string password)
        {
            User userPassword = new User() { Id = id };
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
        public List<User> FindAndFilter(string name)
        {
            return context.Membros.Where(
                                    i => 
                                    i.Nome.Contains(name) ||
                                    i.Sobrenome.Contains(name) ||
                                    i.Username.Contains(name)
                                   ).OrderBy(u => u.Nome).ToList<User>();
        }

        public PageResponse<User> Filter(long id, PageRequest pageRequest)
        {
/* 
            IQueryable<User> query = context.Membros.Where(
                                                    i => 
                                                    i.Nome.Contains(name) ||
                                                    i.Sobrenome.Contains(name) ||
                                                    i.Username.Contains(name)
                                                    )
                                                    .OrderBy(u => u.Nome);
 */
            return null;
        }

    }
}