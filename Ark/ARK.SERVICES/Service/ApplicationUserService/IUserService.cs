using ARK.CORE.Response;
using ARK.DATA.Models;
using ARK.MODEL.V1.Domain.User;
using System.Threading.Tasks;

namespace ARK.SERVICES.Service.ApplicationUserService
{
    public interface IUserService: IService
    {
        Task<ServiceResponse<ApplicationUser>> CreateUserAsync(ApplicationUser model);
        Task<ServiceResponse<string>> GenerateEmailConfirmationTokenAsync(ApplicationUser user);

    }
}
