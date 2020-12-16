using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using temis.core.Models;
using temis.Core.Interfaces;
using temis.Core.Models;
using temis.data.Data;
using MySql.Data.MySqlClient;

namespace temis.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MembroContext context;

        public UserRepository(MembroContext ctx)
        {
            context = ctx;
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
            var userId = new MySqlParameter("@userId", user.Id);
            var userIdade = new MySqlParameter("@userIdade", user.Idade);
            var userNome = new MySqlParameter("@userNome", user.Nome);
            var userPassword = new MySqlParameter("@userPassword", user.Password);
            var userSobrenome = new MySqlParameter("@userSobrenome", user.Sobrenome);
            var userUsername = new MySqlParameter("@userUsername", user.Username);

            context.Database.ExecuteSqlRaw(
                "UPDATE member_tbl SET idade = @userIdade, nome = @userNome, password = @userPassword, sobrenome = @userSobrenome, username = @userUsername WHERE id = @userId", 
                userIdade, userNome, userPassword, userSobrenome, userUsername, userId);

            
            User userNew = FindById(user.Id);
            return userNew;
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
        public PageResponse<User> Filter(string name, PageRequest pageRequest)
        {
            IQueryable<User> query = context.Membros.Where(
                                    i => 
                                    i.Nome.Contains(name) ||
                                    i.Sobrenome.Contains(name) ||
                                    i.Username.Contains(name)
                                   ).OrderBy(u => u.Nome);

            List<User> filtredUser;
            filtredUser = Pagination<User>.For(query, pageRequest).ToList();
            return PageResponse<User>.For(filtredUser, pageRequest, query.Count());
        }

    }
}