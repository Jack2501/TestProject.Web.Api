using YevhenUshakov.TestProject.Model.Settings;

namespace YevhenUshakov.TestProject.Model.Services.Abstract
{
    public interface ISettingsService
    {
        JwtSettings JwtSettings { get; set; }
    }
}
