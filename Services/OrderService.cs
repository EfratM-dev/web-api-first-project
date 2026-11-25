using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Repository;

namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<Order> GetById(int id)
        {
            return await orderRepository.GetById(id);
        }

        public async Task<Order> Post(Order order)
        {
            return await orderRepository.Post(order);
        }
    }
}
