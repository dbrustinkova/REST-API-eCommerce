using System.Collections.Generic;

namespace AppGr8.WebApiECommerce.Services.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Currency_Code { get; set; } = string.Empty;
        //public ICollection<Order> Orders { get; set; } = null!;
    }
}
