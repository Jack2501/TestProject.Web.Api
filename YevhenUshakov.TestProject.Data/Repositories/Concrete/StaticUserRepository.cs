using YevhenUshakov.TestProject.Data.Entities;
using YevhenUshakov.TestProject.Data.Repositories.Abstract;

namespace YevhenUshakov.TestProject.Data.Repositories.Concrete
{
    public class StaticUserRepository : IUserRepository
    {
        public User Get(string email, string password)
        {
            var user = new User();
            if (email == "admin@admin.com" && password == "P@ssword123")
            {
                user.Email = email;
                user.Password = password;
                return user;
            }

            return null;
        }
    }
}
