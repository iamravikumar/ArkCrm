using ARK.CORE.Request;
using ARK.CORE.Response;
using ARK.DATA.Models;

namespace ARK.SERVICES.Service.OrderService
{
    public interface IOrderService : IService
    {
        PagedList<Order> GetOrders(FilterContainer filterContainer);

        
    }
}
