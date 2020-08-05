using AppGr8.WebApiECommerce.Services.Models;
using System.Collections.Generic;

namespace AppGr8.WebApiECommerce.Services
{
    public class ProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public bool Contains(int id)
        {
            return repository.Contains(id);
        }

        public IReadOnlyCollection<Product> GetAll() 
        {
            return repository.GetAll();
        }

        public Product Get(int id)
        {
            return repository.Get(id);
        }

        public Product Create(Product product)
        {
            return repository.Create(product);
        }

        public Product Update(Product product)
        {
            return repository.Update(product);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
