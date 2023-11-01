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
            }).AddEntityFrameworkStores<AuthIdentityDbContext>();
        }

        public static void AddFluentValidationWithExt(this IServiceCollection services)
        {
            services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(ProductDtoValidator))));
            services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(AuthIdentityUserRegisterDtoValidator))));

        }

        public static void AddAutoMapperWithExt(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MapProfile)));
            services.AddAutoMapper(Assembly.GetAssembly(typeof(AuthIdentityMapProfile)));
        }

        public static void AddNotifyWithExt(this IServiceCollection services)
        {
            services.AddRazorPages().AddNToastNotifyNoty(new NotyOptions
            {
                ProgressBar = true,
                Timeout = 10000
            });
        }
    }
}
