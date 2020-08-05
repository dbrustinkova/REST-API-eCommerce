using AppGr8.WebApiECommerce.Services.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace AppGr8.WebApiECommerce.Services
{
    public class OrderService
    {
        private readonly IOrderRepository repository;

        public OrderService(IOrderRepository repository)
        {
            this.repository = repository;
        }

        public IReadOnlyCollection<Order> GetAll()
        {
            return repository.GetAll();
        }

        public Order Get(int id)
        {
            return repository.Get(id);
        }

        public Order Create(Order order)
        {
            return repository.Create(order);
        }

        public bool Contains(int id)
        {
            return repository.Contains(id);
        }

        public Order Update(Order order)
        {
            return repository.Update(order);
        }

        public Order Update(int id, JsonPatchDocument<Order> patch)
        {
            var existingOrder = Get(id);

            patch.ApplyTo(existingOrder);

            return repository.Update(existingOrder);
        }
    }
}
