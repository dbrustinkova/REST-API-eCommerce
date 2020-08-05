using System;

namespace AppGr8.WebApiECommerce.Services.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public decimal Total_Price { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime Created_at { get; set; }
        //public User User { get; set; } = null!;
        //public ICollection<Product> Products { get; set; } = null!;
    }
}
