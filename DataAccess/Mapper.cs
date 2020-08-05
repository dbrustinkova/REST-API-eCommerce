using AppGr8.WebApiECommerce.DataAccess.Entities;
using AppGr8.WebApiECommerce.Services.Models;
using System;

namespace AppGr8.WebApiECommerce.DataAccess
{
    /// <summary>
    /// Mapping objects from different types
    /// </summary>
    public static class Mapper
    {
        public static ProductEntity Map(Product product)
        {
            return new ProductEntity
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image = product.Image
            };
        }

        public static Product Map(ProductEntity productEntity)
        {
            return new Product
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Price = productEntity.Price,
                Image = productEntity.Image
            };
        }

        public static OrderEntity Map(Order order)
        {
            return new OrderEntity
            {
                Id = order.Id,
                User_Id = order.User_Id,
                //Products = order.Products,
                Total_Price = order.Total_Price,
                Status = order.Status,
                Created_at = order.Created_at
            };
        }

        public static Order Map(OrderEntity orderEntity)
        {
            return new Order
            {
                Id = orderEntity.Id,
                User_Id = orderEntity.User_Id,
                //Products = orderEntity.Products,
                Total_Price = orderEntity.Total_Price,
                Status = orderEntity.Status,
                Created_at = DateTime.Now
            };
        }

        public static UserEntity Map(User user)
        {
            return new UserEntity
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                Currency_Code = user.Currency_Code
            };
        }

        public static User Map(UserEntity userEntity)
        {
            return new User
            {
                Id = userEntity.Id,
                UserName = userEntity.UserName,
                Password = userEntity.Password,
                Currency_Code = userEntity.Currency_Code
            };
        }
    }
}
