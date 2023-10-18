using Microsoft.EntityFrameworkCore;
using PLMS.Core.Repositories;
using PLMS.Core.Services;
using PLMS.Core.UnitOfWork;
using PLMS.Repository.Contexts;
using PLMS.Repository.Repositories;
using PLMS.Repository.UnitOfWork;
using System.Reflection;

namespace PLMS.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped(typeof(IUnitOfWork<>),typeof(UnitOfWork<>));
            //builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<,>));
            //builder.Services.AddScoped(typeof(IService<>),typeof(Service<>));



            var env = builder.Environment;
            builder.Configuration.SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json",optional:false)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json",optional:true)
                ;
            builder.Services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), option =>
                {
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
                });
            });
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}