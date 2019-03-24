using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using YevhenUshakov.TestProject.Data.Entities;

namespace YevhenUshakov.TestProject.Data
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly User _user;
        private readonly Role _role;

        public DatabaseInitializer(DataContext dataContext, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _role = new Role
            { 
                Name = "Admin"
            };
            _user = new User
            {
                UserName = "Admin",
                Email = "admin@admin.com",
                EmailConfirmed = true
            };
        }

        public async Task Initialize()
        {
            //_dataContext.Database.Migrate();
            //if (!_dataContext.Users.Any())
            //{
                await _dataContext.Database.EnsureCreatedAsync();
                if (!await _roleManager.RoleExistsAsync(_role.Name))
                {
                    await _roleManager.CreateAsync(_role);
                }

                if (await _userManager.FindByEmailAsync(_user.Email) == null)
                {
                    var result = await _userManager.CreateAsync(_user, "P@ssword123");
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(_user, _role.Name);
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
                //var profile = new UserProfile
                //{
                //    UserId = user.Id,
                //    FirstName = "John",
                //    LastName = "Doe",
                //    BirthDate = DateTime.Now.AddDays(-1)
                //};

                //_dataContext.UserProfiles.Add(profile);
                //_dataContext.SaveChanges();
            //}
        }
    }
}
