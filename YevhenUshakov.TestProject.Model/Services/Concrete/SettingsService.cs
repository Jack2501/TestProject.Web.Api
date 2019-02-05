using YevhenUshakov.TestProject.Model.Services.Abstract;
using YevhenUshakov.TestProject.Model.Settings;

namespace YevhenUshakov.TestProject.Model.Services.Concrete
{
    public class SettingsService : ISettingsService
    {
        public JwtSettings JwtSettings { get; set; }

        public SettingsService(JwtSettings jwtSettings)
        {
            JwtSettings = jwtSettings;
        }
    }
}
