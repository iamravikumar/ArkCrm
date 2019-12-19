using ARK.CORE.Response;
using ARK.MODEL.V1.Domain.Radius;
using ARK.RADIUS.Models;

namespace ARK.BUSINESS.Domain
{
    public interface IRadiusBusiness : IBusiness
    {
        ServiceResponse<Nas> GetNas();
    }
}
