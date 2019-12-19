using System.Threading.Tasks;
using ARK.DATA.Models;
using Microsoft.AspNetCore.Identity;
using System;
using ARK.CORE.Response;

namespace ARK.SERVICES.Service.ApplicationUserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public UserService(
            UserManager<ApplicationUser> userManager
            , SignInManager<IdentityUser> signInManager
            )
        {
            _userManager = userManager;
        }
        public async Task<ServiceResponse<ApplicationUser>> CreateUserAsync(ApplicationUser model)
        {
            try
            {
                var result = await _userManager.CreateAsync(model, model.PasswordHash);
                if (result.Succeeded)                
                    return new ServiceResponse<ApplicationUser>(model, true, 100, "");
                foreach (var error in result.Errors)
                {
                    return new ServiceResponse<ApplicationUser>(new ServiceError(error.Code, error.Description), false, 101, "");
                }
                return new ServiceResponse<ApplicationUser>(false, 101, "");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<ApplicationUser>(ex);
            }
        }

        public async Task<ServiceResponse<string>> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            try
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                return new ServiceResponse<string>(code, true, 100, "");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<string>(ex);
            }
        }
    }
}
