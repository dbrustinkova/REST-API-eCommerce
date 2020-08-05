using AppGr8.WebApiECommerce.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AppGr8.WebApiECommerce.DataAccess.MockData
{
    /// <summary>
    /// This class is used to get *SeedData.json and convert it into objects and add to database
    /// </summary>
    public class Seed
    {
        public static async Task SeedProducts(DataContext dataContext)
        {
            if (!dataContext.Products.Any())
            {
                var fileName = "\\DataAccess\\MockData\\ProductsSeedData.json";
                var currentDirectory = Environment.CurrentDirectory;
                var fullPath = Directory.GetParent(currentDirectory).FullName;
                fullPath += fileName;
                var data = await File.ReadAllTextAsync(fullPath);
                var products = JsonConvert.DeserializeObject<List<Product>>(data);

                foreach (var product in products)
                {
                    await dataContext.Products.AddAsync(Mapper.Map(product));
                }

                await dataContext.SaveChangesAsync();
            }
        }

        public static async Task SeedUsers(DataContext dataContext)
        {
            if (!dataContext.Users.Any())
            {
                var fileName = "\\DataAccess\\MockData\\UsersSeedData.json";
                var currentDirectory = Environment.CurrentDirectory;
                var fullPath = Directory.GetParent(currentDirectory).FullName;
                fullPath += fileName;
                var data = await File.ReadAllTextAsync(fullPath);
                var users = JsonConvert.DeserializeObject<List<User>>(data);

                foreach (var user in users)
                {
                    await dataContext.Users.AddAsync(Mapper.Map(user));
                }

                await dataContext.SaveChangesAsync();
            }
        }

        public static async Task SeedOrders(DataContext dataContext)
        {
            if (!dataContext.Orders.Any())
            {
                var fileName = "\\DataAccess\\MockData\\OrdersSeedData.json";
                var currentDirectory = Environment.CurrentDirectory;
                var fullPath = Directory.GetParent(currentDirectory).FullName;
                fullPath += fileName;
                var data = await File.ReadAllTextAsync(fullPath);
                var orders = JsonConvert.DeserializeObject<List<Order>>(data);

                foreach (var order in orders)
                {
                    await dataContext.Orders.AddAsync(Mapper.Map(order));
                }

                await dataContext.SaveChangesAsync();
            }
        }
    }
}
