namespace AppGr8.WebApiECommerce.Services.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
        //public Order Order { get; set; } = null!;
    }
}
