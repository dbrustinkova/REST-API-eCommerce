namespace AppGr8.WebApiECommerce.DataAccess.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
        //public OrderEntity Order { get; set; } = null!;
    }
}
