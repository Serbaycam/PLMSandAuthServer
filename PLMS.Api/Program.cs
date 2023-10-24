using AuthIdentity.Core.Entities;
using AuthIdentity.Repository.Contexts;

namespace PLMS.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(opt => opt.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(ProductDtoValidator))));
            builder.Services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddScoped(typeof(NotFoundFilter<,>));
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
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCustomException();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}