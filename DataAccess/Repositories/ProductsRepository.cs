using AppGr8.WebApiECommerce.Services;
using AppGr8.WebApiECommerce.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace AppGr8.WebApiECommerce.DataAccess
{
    public class ProductsRepository : IProductRepository
    {
        private readonly DataContext dataContext;

        public ProductsRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Product Create(Product product)
        {
            var productEntity = Mapper.Map(product);

            dataContext.Products.Add(productEntity);
            dataContext.SaveChanges();

            return Mapper.Map(productEntity);
        }

        public IReadOnlyCollection<Product> GetAll()
        {
            return dataContext.Products.Select(p => Mapper.Map(p)).ToList();
        }

        public Product Get(int id)
        {
            var productEntity = dataContext.Products.Find(id);
            return Mapper.Map(productEntity);
        }

        public Product Update(Product product)
        {
            var productEntity = dataContext.Products.Find(product.Id);

            productEntity.Name = product.Name;
            productEntity.Price = product.Price;
            productEntity.Image = product.Image;

            dataContext.Products.Update(productEntity);
            dataContext.SaveChanges();

            return Mapper.Map(productEntity);
        }

        public void Delete(int id)
        {
            var productEntity = dataContext.Products.Find(id);

            dataContext.Products.Remove(productEntity);
            dataContext.SaveChanges();
        }

        public bool Contains(int id)
        {
            return dataContext.Products.Any(p => p.Id == id);
        }
    }
}
