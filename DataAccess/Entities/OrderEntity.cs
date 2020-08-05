using System;

namespace AppGr8.WebApiECommerce.DataAccess.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public decimal Total_Price { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime Created_at { get; set; }
        //public UserEntity User { get; set; } = null!;
        //public ICollection<ProductEntity> Products { get; set; } = null!;
    }
}
