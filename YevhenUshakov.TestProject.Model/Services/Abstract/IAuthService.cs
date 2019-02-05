using YevhenUshakov.TestProject.Model.Auth;

namespace YevhenUshakov.TestProject.Model.Services.Abstract
{
    public interface IAuthService
    {
        TokenModel Login(LoginModel model);
    }
}
