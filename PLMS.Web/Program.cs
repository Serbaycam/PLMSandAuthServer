namespace PLMS.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddFluentValidationWithExt();
            builder.Services.AddNotifyWithExt();
            builder.Services.AddAutoMapperWithExt();

            var env = builder.Environment;
            builder.Configuration.SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                ;
            builder.Services.AddDbContexesWithExt(builder);
            builder.Services.AddConfigureSecurityStampWithExt();
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

            builder.Services.AddIdentityWithExt();
            builder.Services.AddCookieOptionsWithExt();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseStatusCodePagesWithReExecute("/Account/Account/Error");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseNToastNotify();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area}/{controller=Account}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "Default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}