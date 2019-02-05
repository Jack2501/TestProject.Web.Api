using Moq;
using YevhenUshakov.TestProject.Model.Services.Abstract;
using YevhenUshakov.TestProject.Web.Api.Controllers;

namespace YevhenUshakov.TestProject.UnitTests.Web.Api.AuthControllerTests
{
    public class AuthControllerSut
    {
        public AuthController Instance { get; set; }
        public Mock<IAuthService> AuthService { get; set; }

        public AuthControllerSut()
        {
            AuthService = new Mock<IAuthService>();
            Instance = new AuthController(AuthService.Object);
        }
    }
}
