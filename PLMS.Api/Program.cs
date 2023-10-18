
using Microsoft.EntityFrameworkCore;
using PLMS.Core.Repositories;
using PLMS.Core.UnitOfWork;
using PLMS.Repository.Contexts;
using PLMS.Repository.Repositories;
using PLMS.Repository.UnitOfWork;
using System.Reflection;

namespace PLMS.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            //builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<,>));
            //builder.Services.AddScoped(typeof(IService<>),typeof(Service<>));
            var env = builder.Environment;
            builder.Configuration.SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
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
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}