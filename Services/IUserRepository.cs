using AppGr8.WebApiECommerce.Services.Models;
using System.Collections.Generic;

namespace AppGr8.WebApiECommerce.Services
{
    public interface IUserRepository
    {
        bool UserExist(string username, string pass);
        bool Contains(int id);
        User Create(User user);
        void Delete(int id);
        User Get(int id);
        IReadOnlyCollection<User> GetAll();
        User Update(User user);
    }
}
