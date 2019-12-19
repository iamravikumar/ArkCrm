using ARK.CORE.Response;
using ARK.MODEL.V1.Domain.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ARK.BUSINESS.Domain
{
    public interface IUserBusiness : IBusiness
    {
        TokenModel Authenticate(string username, string password);
        IEnumerable<UserModel> GetAll();

        Task<ServiceResponse<UserModel>> CreateUserAsync(UserModel model);
    }
}
