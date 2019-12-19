using ARK.CORE.Data;
using ARK.CORE.Request;
using ARK.CORE.Response;
using ARK.DATA.Models;
using System;

namespace ARK.SERVICES.Service.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }


        // Methods
        public PagedList<Order> GetOrders(FilterContainer filterContainer)
        {
            try
            {
                var asd = _orderRepository.TableNoTracking;

                return new PagedList<Order>(asd, filterContainer);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
