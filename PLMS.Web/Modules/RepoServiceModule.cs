namespace PLMS.Web.Modules
{
    public class RepoServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<,>)).As(typeof(IGenericRepository<,>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericService<,>)).As(typeof(IGenericService<,>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>)).InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(AuthIdentityGenericRepository<,>)).As(typeof(IAuthIdentityGenericRepository<,>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(AuthIdentityGenericService<,>)).As(typeof(IAuthIdentityGenericService<,>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(AuthIdentityUnitOfWork<>)).As(typeof(IAuthIdentityUnitOfWork<>)).InstancePerLifetimeScope();



            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(PLMSDbContext));
            var repoAssembly2 = Assembly.GetAssembly(typeof(AuthIdentityDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));
            var serviceAssembly2 = Assembly.GetAssembly(typeof(AuthIdentityMapProfile));


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly2, serviceAssembly2).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly2, serviceAssembly2).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();


        }
    }
}
