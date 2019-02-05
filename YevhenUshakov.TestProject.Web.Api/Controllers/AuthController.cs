using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YevhenUshakov.TestProject.Model.Auth;
using YevhenUshakov.TestProject.Model.Services.Abstract;
using YevhenUshakov.TestProject.Web.Api.Model;

namespace YevhenUshakov.TestProject.Web.Api.Controllers
{
    public class AuthController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route(Routes.Login)]
        public ApiResponse<TokenModel> Login([FromBody] LoginModel model)
        {
            TokenModel token = _authService.Login(model);
            return new ApiResponse<TokenModel>(token);
        }
    }
}
