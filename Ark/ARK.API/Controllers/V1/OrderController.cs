using ARK.BUSINESS.Domain;
using ARK.CORE.Request;
using ARK.CORE.Response;
using ARK.DATA.Models;
using ARK.MODEL.V1.Domain.Order;
using Microsoft.AspNetCore.Mvc;

namespace ARK.API.Controllers.V1
{
    public class OrderController : BaseController
    {
        private IOrderBusiness _orderBusiness;

        public OrderController(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }

        /// <summary>
        /// asd
        /// </summary>
        /// <remarks>asd remarks</remarks>
        [HttpGet("getFilteredOrders", Name = "getFilteredOrders")]
        [ProducesResponseType(typeof(ServiceResponse<OrderModel>), 200)]
        public ServiceResponse<Order> GetFilteredOrders([FromQuery] RequestFilter requestFilter)
        {
            return _orderBusiness.GetFilteredOrders(MapQueryFilter(requestFilter));            
        }


    }
}
