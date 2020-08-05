using AppGr8.WebApiECommerce.Services.Models;
using System.Collections.Generic;

namespace AppGr8.WebApiECommerce.Services
{
    public class UserService : IUserRepository
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return repository.GetAll();
        }

        public User Get(int id)
        {
            return repository.Get(id);
        }

        public User Create(User user)
        {
            return repository.Create(user);
        }

        public User Update(User user)
        {
            return repository.Update(user);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public bool Contains(int id)
        {
            return repository.Contains(id);
        }

        public bool UserExist(string username, string pass)
        {
            return repository.UserExist(username, pass);
        }
    }
}
