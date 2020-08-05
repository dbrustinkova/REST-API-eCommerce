using AppGr8.WebApiECommerce.Services.Models;
using Swashbuckle.AspNetCore.Filters;

namespace AppGr8.WebApiECommerce.Api.Examples
{
    /// <summary>
    /// examples for the swagger
    /// </summary>
    public class ProductExamples : IExamplesProvider<Product>
    {
        public Product GetExamples()
        {
            return new Product
            {
                Id = 0,
                Name = "Pleated Palazzo Trousers TRF",
                Price = 29.95m,
                Image = "https://cf.shopee.ph/file/fecc650ca5802d709890a66cc00cfe23"
            };
        }
    }

    public class UserExamples : IExamplesProvider<User>
    {
        public User GetExamples()
        {
            return new User
            {
                Id = 0,
                UserName = "admin",
                Password = "123",
                Currency_Code = "BGN"
            };
        }
    }
}
