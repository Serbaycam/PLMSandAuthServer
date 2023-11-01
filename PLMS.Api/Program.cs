namespace PLMS.Api
{
    public class Program
    {
        [Obsolete]
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddFluentValidationWithExt();
            builder.Services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddScoped(typeof(NotFoundFilter<,>));
            builder.Services.AddAutoMapperWithExt();

            var env = builder.Environment;
            builder.Configuration.SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                ;
            builder.Services.AddDbContext<PLMSDbContext>(x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("PLMSConnection"), option =>
                {
                    option.MigrationsAssembly(Assembly.GetAssembly(typeof(PLMSDbContext)).GetName().Name);
                });
            });

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));
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