using AppGr8.WebApiECommerce.Services;
using AppGr8.WebApiECommerce.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace AppGr8.WebApiECommerce.DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext dataContext;

        public OrderRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IReadOnlyCollection<Order> GetAll()
        {
            return dataContext.Orders.Select(t => Mapper.Map(t)).ToList();
        }

        public Order Get(int id)
        {
            var orderEntity = dataContext.Orders.Find(id);
            return Mapper.Map(orderEntity);
        }

        public Order Create(Order order)
        {
            var orderEntity = Mapper.Map(order);

            dataContext.Orders.Add(orderEntity);
            dataContext.SaveChanges();

            return Mapper.Map(orderEntity);
        }

        public bool Contains(int id)
        {
            return dataContext.Orders.Any(o => o.Id == id);
        }

        public Order Update(Order order)
        {
            var orderEntity = dataContext.Orders.Find(order.Id);

            orderEntity.Status = order.Status;

            dataContext.Orders.Update(orderEntity);
            dataContext.SaveChanges();

            return Mapper.Map(orderEntity);
        }
    }
}
