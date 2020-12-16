using System;
using System.Collections.Generic;
using temis.Core.Interfaces;
using temis.Core.Models;
using temis.Core.Services.Interfaces;

namespace temis.Core.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User CreateUser(User user)
        {
            User userNew = _repository.CreateUser(user);
            return userNew;
        }

        public User EditUser(User user)
        {
            User editedUser = _repository.EditUser(user);
            return editedUser;
        }

        public List<User> FindAll()
        {
            List<User> list = new List<User>();
            list = _repository.FindAll();
            return list;
        }

        public User FindById(long id)
        {
            User user = _repository.FindById(id);
            return user;
        }

        public void EditPassword(long id, string password)
        {
            User user = _repository.FindById(id);
            if(user == null)
            {
                throw new NullReferenceException("Usuário não cadastrado!");
            }
            _repository.EditPassword(user.Id, password);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public PageResponse<User> Filter(long id, PageRequest pageRequest)
        {
            return _repository.Filter(id, pageRequest);
        }
    }
}
