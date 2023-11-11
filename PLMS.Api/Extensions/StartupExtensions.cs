namespace PLMS.Api.Extensions
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

#pragma warning disable CA1041 // Provide ObsoleteAttribute message
        [Obsolete]
#pragma warning restore CA1041 // Provide ObsoleteAttribute message
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
    }
}
