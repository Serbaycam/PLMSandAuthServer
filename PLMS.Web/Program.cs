namespace PLMS.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(ProductDtoValidator))));
            builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(AuthIdentityUserRegisterDtoValidator))));


            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MapProfile)));
            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(AuthIdentityMapProfile)));

            var env = builder.Environment;
            builder.Configuration.SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                ;
            builder.Services.AddDbContext<AuthIdentityDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("AuthIdentityConnection"), option =>
                {
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AuthIdentityDbContext)).GetName().Name);
                });
            });
            builder.Services.AddDbContext<PLMSDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("PLMSConnection"), option =>
                {
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(PLMSDbContext)).GetName().Name);
                });
            });
          
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

            builder.Services.AddIdentity<AuthIdentityUser, AuthIdentityRole>().AddEntityFrameworkStores<AuthIdentityDbContext>();

            
            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "areas",
                    areaName: "areas",
                    pattern: "{area}/{controller=Account}/{action=Index}/{id?}"
                    );
            });

            app.Run();
        }
    }
}