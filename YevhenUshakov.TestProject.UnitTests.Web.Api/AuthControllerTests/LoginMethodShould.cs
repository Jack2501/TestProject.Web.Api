using System;
using Moq;
using Xunit;
using YevhenUshakov.TestProject.Model.Auth;
using YevhenUshakov.TestProject.Web.Api.Model;

namespace YevhenUshakov.TestProject.UnitTests.Web.Api.AuthControllerTests
{
    public class LoginMethodShould
    {
        public AuthControllerSut Sut { get; set; }

        public LoginMethodShould()
        {
            Sut = new AuthControllerSut();
        }

        [Fact]
        public void ReturnStatusOneWhenLoginModelIsNull()
        {
            // Arrange
            var expectedResult = new ApiResponse<TokenModel>
            {
                Status = 1,
                Description = "Success",
                Timestamp = 1234567,
                Model = null
            };

            // Action
            var actualResult = Sut.Instance.Login(null);

            // Assert
            Assert.Equal(expectedResult.Status, actualResult.Status);
        }

        [Fact]
        public void ReturnDescriptionSuccessWhenLoginModelIsNull()
        {
            // Arrange
            var expectedResult = new ApiResponse<TokenModel>
            {
                Timestamp = 123456789,
                Description = "Success",
                Status = 1
            };

            // Action
            var actualResult = Sut.Instance.Login(null);

            // Assert
            Assert.IsType<ApiResponse<TokenModel>>(actualResult);
            Assert.Equal(expectedResult.Description, actualResult.Description);
        }

        [Fact]
        public void ReturnModelNullWhenLoginModelIsNull()
        {
            // Arrange
            // Action
            var actual = Sut.Instance.Login(null);

            // Assert
            Assert.IsType<ApiResponse<TokenModel>>(actual);
            Assert.Null(actual.Model);
        }

        [Fact]
        public void ReturnValidAccessToken()
        {
            // Arrange
            var loginModel = new LoginModel
            {
                Login = "test@email.com",
                Password = "1234qwer"
            };

            var expectedResult = new ApiResponse<TokenModel>
            {
                Model = new TokenModel { AccessToken = "1234567890", ExpiresIn = DateTime.UtcNow.AddDays(1) },
                Timestamp = 123456789,
                Description = "Success",
                Status = 1
            };

            Sut.AuthService.Setup(x => x.Login(It.IsAny<LoginModel>())).Returns(new TokenModel { AccessToken = "1234567890", ExpiresIn = DateTime.UtcNow.AddDays(1) });

            // Action
            var actualResult = Sut.Instance.Login(loginModel);

            // Assert
            Assert.Equal(expectedResult.Model.AccessToken, actualResult.Model.AccessToken);
        }

        [Fact]
        public void ReturnValidExpirationDate()
        {
            // Arrange
            var loginModel = new LoginModel
            {
                Login = "test@email.com",
                Password = "1234qwer"
            };

            var expectedResult = new ApiResponse<TokenModel>
            {
                Model = new TokenModel { AccessToken = "1234567890", ExpiresIn = DateTime.UtcNow.AddDays(1) },
                Timestamp = 123456789,
                Description = "Success",
                Status = 1
            };

            Sut.AuthService.Setup(x => x.Login(It.IsAny<LoginModel>())).Returns(new TokenModel { AccessToken = "1234567890", ExpiresIn = DateTime.UtcNow.AddDays(1) });

            // Action
            var actualResult = Sut.Instance.Login(loginModel);

            // Assert
            Assert.Equal(expectedResult.Model.ExpiresIn.Date, actualResult.Model.ExpiresIn.Date);
        }
    }
}
