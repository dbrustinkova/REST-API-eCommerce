namespace AppGr8.WebApiECommerce.DataAccess.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Currency_Code { get; set; } = string.Empty;
        //public ICollection<OrderEntity> Orders { get; set; } = null!;
    }
}
