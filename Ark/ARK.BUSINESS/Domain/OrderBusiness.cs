using ARK.CORE.Request;
using ARK.CORE.Response;
using ARK.DATA.Models;
using ARK.MODEL.V1.Domain.Order;
using ARK.SERVICES.Service.OrderService;
using System;

namespace ARK.BUSINESS.Domain
{
    public class OrderBusiness : IOrderBusiness
    {
        private IOrderService _orderService;

        public OrderBusiness(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public ServiceResponse<Order> GetFilteredOrders(FilterContainer filterContainer)
        {
            try
            {
                var asd = _orderService.GetOrders(filterContainer);

                return new ServiceResponse<Order>(asd,
                                                  asd.PageNumber,
                                                  asd.PageSize,
                                                  asd.TotalCount,
                                                  asd.TotalPages,
                                                  asd.HasNextPage,
                                                  asd.HasPreviousPage,
                                                  true,
                                                  100,
                                                  "Order başarılı");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
