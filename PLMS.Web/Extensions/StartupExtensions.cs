using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace PLMS.Web.Extensions
{
    public static class StartupExtensions
    {
        public static void AddIdentityWithExt(this IServiceCollection services)
        {
            services.AddIdentity<AuthIdentityUser, AuthIdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;


                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 3;

            }).AddEntityFrameworkStores<AuthIdentityDbContext>();
        }

        public static void AddConfigureSecurityStampWithExt(this IServiceCollection services)
        {
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromMinutes(5);
            });
        }

        public static void AddFluentValidationWithExt(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining(typeof(ProductDtoValidator));
            services.AddValidatorsFromAssemblyContaining(typeof(AuthIdentityUserRegisterDtoValidator));

        }


        public static void AddCookieOptionsWithExt(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                CookieBuilder cookieBuilder = new()
                {
                    Name = "PLMSWebApp"
                };
                options.LoginPath = new PathString("/Account/Account/Login");
                options.AccessDeniedPath = new PathString("/Account/Account/AccessDenied");
                options.Cookie = cookieBuilder;
                options.ExpireTimeSpan = TimeSpan.FromDays(12);
                options.SlidingExpiration = true;


            });
        }

        public static void AddAutoMapperWithExt(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MapProfile)));
            services.AddAutoMapper(Assembly.GetAssembly(typeof(AuthIdentityMapProfile)));
        }

        public static void AddNotifyWithExt(this IServiceCollection services)
        {
            services.AddMvc().AddNToastNotifyToastr();
        }

        public static void AddDbContexesWithExt(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<AuthIdentityDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("AuthIdentityConnection"), option =>
                {
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AuthIdentityDbContext)).GetName().Name);
                });
            });
            services.AddDbContext<PLMSDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("PLMSConnection"), option =>
                {
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(PLMSDbContext)).GetName().Name);
                });
            });
        }
    }
}
