using YevhenUshakov.TestProject.Data.Entities;

namespace YevhenUshakov.TestProject.Data.Repositories.Abstract
{
    public interface IUserRepository
    { 
        User Get(string email, string password);
    }
}
