using ARK.BUSINESS.Domain;
using ARK.CORE.Request;
using ARK.CORE.Response;
using ARK.DATA.Models;
using ARK.MODEL.V1.Domain.Address;
using Microsoft.AspNetCore.Mvc;

namespace ARK.API.Controllers.V1
{
    public class AddressController : BaseController
    {
        private IAddressBusiness _addressBusiness;

        public AddressController(IAddressBusiness addressBusiness)
        {
            _addressBusiness = addressBusiness;
        }


        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [HttpGet("getFilteredNationalitiesM", Name = "getFilteredNationalitiesM")]
        [ProducesResponseType(typeof(ServiceResponse<AddressNationalityModel>), 200)]
        public ServiceResponse<AddressNationality> GetNationalities([FromQuery] RequestFilter requestFilter)
        {
            return _addressBusiness.GetFilteredNationalities(MapQueryFilter(requestFilter));
        }
    }
}