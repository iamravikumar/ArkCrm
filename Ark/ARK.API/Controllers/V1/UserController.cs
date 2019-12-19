using ARK.BUSINESS.Domain;
using ARK.MODEL.V1.Domain.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ARK.API.Controllers.V1
{
    [Authorize]
    public class UserController : BaseController
    {
        private IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [AllowAnonymous]
        [HttpPost("authenticate", Name = "authenticate")]
        [ProducesResponseType(typeof(UserLoginModel), 200)]
        public IActionResult Authenticate([FromBody]UserLoginModel userParam)
        {
            var user = _userBusiness.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("createUser", Name = "createUser")]
        [ProducesResponseType(typeof(UserModel), 200)]
        public async Task<IActionResult> CreateUser()
        {
            var model = new UserModel
            {
                BirthDate = 123,
                AccessFailedCount = 1,
                ConcurrencyStamp = "",
                CreateDate = 123,
                CreateUser = 1,
                DeleteDate = 123,
                DeleteUser = 1,
                Email = "hllkc@hotmail.com",
                EmailConfirmed = false,
                FirstName = "Halil",
                GenderId = 1,
                IdentityNumber = "52108492584",
                IsDeleted = false,
                LastName = "Koca",
                LockoutEnabled = false,
                MidName = "",
                NormalizedEmail = "hllkc@hotmail.com",
                NormalizedUserName = "52108492584",
                PasswordHash = "a.A123",
                PhoneNumber = "+905327320230",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                UserName = "52108492584"
            };

            var asd = await _userBusiness.CreateUserAsync(model).ConfigureAwait(true);
            model = asd.Data;

            return Ok(model);
        }
    }
}
