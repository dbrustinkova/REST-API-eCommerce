using AppGr8.WebApiECommerce.Services;
using AppGr8.WebApiECommerce.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace AppGr8.WebApiECommerce.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dataContext;

        public UserRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public User Create(User user)
        {
            var userEntity = Mapper.Map(user);

            dataContext.Users.Add(userEntity);
            dataContext.SaveChanges();

            return Mapper.Map(userEntity);
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return dataContext.Users.Select(p => Mapper.Map(p)).ToList();
        }

        public User Get(int id)
        {
            var userEntity = dataContext.Users.Find(id);
            return Mapper.Map(userEntity);
        }

        public User Update(User user)
        {
            var userEntity = dataContext.Users.Find(user.Id);

            userEntity.UserName = user.UserName;
            userEntity.Password = user.Password;
            userEntity.Currency_Code = user.Currency_Code;

            dataContext.Users.Update(userEntity);
            dataContext.SaveChanges();

            return Mapper.Map(userEntity);
        }

        public void Delete(int id)
        {
            var userEntity = dataContext.Users.Find(id);

            dataContext.Users.Remove(userEntity);
            dataContext.SaveChanges();
        }

        public bool Contains(int id)
        {
            return dataContext.Users.Any(u => u.Id == id);
        }

        public bool UserExist(string username, string pass)
        {
            return dataContext.Users.Any(u => u.UserName == username && u.Password == pass);
        }
    }
}
