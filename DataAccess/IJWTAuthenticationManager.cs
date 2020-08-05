using AppGr8.WebApiECommerce.Services.Models;

namespace AppGr8.WebApiECommerce.DataAccess
{
    public interface IJWTAuthenticationManager
    {
        string GenerateToken(User user);
    }
}
