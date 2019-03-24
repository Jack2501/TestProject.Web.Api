using Microsoft.AspNetCore.Identity;
using YevhenUshakov.TestProject.Data.Entities;
using YevhenUshakov.TestProject.Data.Repositories.Abstract;

namespace YevhenUshakov.TestProject.Data.Repositories.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserRepository(DataContext dataContext, UserManager<User> userManager, IPasswordHasher<User> passwordHasher) : base(dataContext)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        public User Get(string email, string password)
        {
            var user = _userManager.FindByEmailAsync(email).Result;
            if (user != null)
            {
                if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Success)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
