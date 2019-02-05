using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using YevhenUshakov.TestProject.Data.Entities;
using YevhenUshakov.TestProject.Data.Repositories.Abstract;
using YevhenUshakov.TestProject.Data.Repositories.Concrete;
using YevhenUshakov.TestProject.Model.Auth;
using YevhenUshakov.TestProject.Model.Services.Abstract;
using YevhenUshakov.TestProject.Model.Services.Concrete;
using YevhenUshakov.TestProject.Model.Settings;
using YevhenUshakov.TestProject.Web.Api.Utilities.Filters;
using YevhenUshakov.TestProject.Web.Api.Utilities.Middleware;

namespace YevhenUshakov.TestProject.Web.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly ISettingsService _settingsService;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            var jwtSettings = new JwtSettings();

            Configuration.Bind(nameof(JwtSettings), jwtSettings);

            _settingsService = new SettingsService(jwtSettings);
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<User, Role>(opts =>
            {
                opts.Password.RequiredLength = 5;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
                opts.SignIn.RequireConfirmedEmail = true;
            })
                .AddDefaultTokenProviders();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _settingsService.JwtSettings.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settingsService.JwtSettings.Key)),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddCors();
            services.AddResponseCaching();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();
            AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();
            services.AddSingleton(Log.Logger);

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
                config.Filters.Add(new ValidateModelStateFilter());
            }).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<LoginModel>());

            // Services
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IProductService, ProductService>();

            // Repositories
            services.AddTransient<IProductRepository, StaticProductRepository>();
            services.AddTransient<IUserRepository, StaticUserRepository>();

            // Settings
            services.AddSingleton(_settingsService);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("X-File-Name"));

            app.UseAuthentication();

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
        }
    }
}
