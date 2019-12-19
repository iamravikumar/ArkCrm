using ARK.CORE.Request;
using ARK.CORE.Response;
using ARK.DATA.Models;
using ARK.MODEL.V1.Domain.Order;

namespace ARK.BUSINESS.Domain
{
    public interface IOrderBusiness : IBusiness
    {
        ServiceResponse<Order> GetFilteredOrders(FilterContainer filterContainer);
    }
}
