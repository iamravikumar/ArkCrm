using ARK.CORE.Request;
using ARK.CORE.Response;
using ARK.DATA.Models;
using ARK.MODEL.V1.Domain.Address;

namespace ARK.BUSINESS.Domain
{
    public interface IAddressBusiness : IBusiness
    {
        ServiceResponse<AddressNationality> GetFilteredNationalities(FilterContainer filterContainer);
    }
}
