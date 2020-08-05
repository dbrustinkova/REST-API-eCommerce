using AppGr8.WebApiECommerce.Services.Models;
using System.Collections.Generic;

namespace AppGr8.WebApiECommerce.Services
{
    public interface IOrderRepository
    {
        Order Get(int id);
        IReadOnlyCollection<Order> GetAll();
        bool Contains(int id);
        Order Create(Order order);
        Order Update(Order order);
    }
}
