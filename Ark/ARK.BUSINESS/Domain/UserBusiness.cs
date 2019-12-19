using ARK.CORE.Infrastructure;
using ARK.CORE.Response;
using ARK.DATA.Models;
using ARK.MODEL.V1.Domain.Application;
using ARK.MODEL.V1.Domain.User;
using ARK.SERVICES.Service.ApplicationUserService;
using ARK.SERVICES.Service.Email;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ARK.BUSINESS.Domain
{
    public class UserBusiness : IUserBusiness
    {
        private IUserService _userService;
        private readonly AppSettings _appSettings;
        private IEmailService _emailService;
        public UserBusiness(
            IUserService userService
            , IOptions<AppSettings> appSettings
            ,IEmailService emailService
            )
        {
            _userService = userService;
            _appSettings = appSettings.Value;
            _emailService = emailService;
        }

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<UserModel> _users = new List<UserModel>
        {
            new UserModel { Id = 1, FirstName = "Test", LastName = "User", FullName="Halil Koca", UserName = "test", PasswordHash = "test", Email = "halil" }
        };

        public TokenModel Authenticate(string username, string password)
        {
            try
            {
                var user = _users.SingleOrDefault(x => x.UserName == username && x.PasswordHash == password);

                // return null if user not found
                if (user == null)
                    return null;

                return GenerateJwtToken(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private TokenModel GenerateJwtToken(UserModel user)
        {

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("FullName", user.FullName),
                    new Claim("EmailAddress", user.Email),
                    new Claim("asd", Guid.NewGuid().ToString()),
                    new Claim("UserId", user.Id.ToString()),
                    //new Claim(ClaimTypes.Role, user.RoleName),
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return new TokenModel { Token = token, ValidFrom = securityToken.ValidFrom, ValidTo = securityToken.ValidTo };

        }

        public IEnumerable<UserModel> GetAll()
        {
            // return users without passwords
            return _users.Select(x =>
            {
                x.PasswordHash = null;
                return x;
            });
        }

        public async Task<ServiceResponse<UserModel>> CreateUserAsync(UserModel model)
        {
            try
            {
                var createResult = await _userService.CreateUserAsync(ConvertExtension.Convert<ApplicationUser>(model));
                if (createResult.IsSuccessful)
                {
                    var asd = await _userService.GenerateEmailConfirmationTokenAsync(createResult.Data);


                    var callbackUrl = "/Account/ConfirmEmail?userId= " + createResult.Data.Id + "&code=" + asd.Data + "";
                    //var callbackUrl = Url.Page("/Account/ConfirmEmail", pageHandler: null, values: new { userId = user.Id, code = code }, protocol: Request.Scheme);

                    await _emailService.SendEmailAsync(model.Email, "Üyelik Aktifleştirme",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                }

                return new ServiceResponse<UserModel>();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
