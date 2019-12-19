using ARK.CORE.Request;
using ARK.CORE.Response;
using ARK.DATA.Models;
using ARK.MODEL.V1.Domain.Address;
using ARK.SERVICES.Service.Address;
using System;

namespace ARK.BUSINESS.Domain
{
    public class AddressBusiness : IAddressBusiness
    {
        private IAddressService _addressService;

        public AddressBusiness(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public ServiceResponse<AddressNationality> GetFilteredNationalities(FilterContainer filterContainer)
        {
            try
            {
                var asd = _addressService.GetNationalities(filterContainer).Result;

                return new ServiceResponse<AddressNationality>(asd,
                                                               asd.PageNumber,
                                                               asd.PageSize,
                                                               asd.TotalCount,
                                                               asd.TotalPages,
                                                               asd.HasNextPage,
                                                               asd.HasPreviousPage,
                                                               true,
                                                               100,
                                                               "");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
