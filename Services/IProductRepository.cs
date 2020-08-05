using AppGr8.WebApiECommerce.Services.Models;
using System.Collections.Generic;

namespace AppGr8.WebApiECommerce.Services
{
    public interface IProductRepository
    {
        bool Contains(int id);
        Product Create(Product product);
        void Delete(int id);
        Product Get(int id);
        IReadOnlyCollection<Product> GetAll();
        Product Update(Product product);
    }
}
