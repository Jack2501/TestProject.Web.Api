using System;

namespace YevhenUshakov.TestProject.Model.Auth
{
    public class TokenModel
    {
        public string AccessToken { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
