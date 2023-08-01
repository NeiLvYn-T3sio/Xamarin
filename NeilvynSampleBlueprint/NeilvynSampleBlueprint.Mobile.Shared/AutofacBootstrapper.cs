using Autofac;
using NeilvynSampleBlueprint.Mobile.Shared.Modules;

namespace NeilvynSampleBlueprint.Mobile.Shared
{
    public static class AutofacBootstrapper
    {
        public static ILifetimeScope Instance { get; set; }

        public static void RegisterAutofacModule()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new PlatformModule());

            containerBuilder.RegisterModule(new PersistanceModule());

            containerBuilder.RegisterModule(new ServicesModule());
            
            containerBuilder.RegisterModule(new XamarinServicesModule());

            containerBuilder.RegisterModule(new PageModule());

            Instance = containerBuilder.Build().BeginLifetimeScope();
        }
    }
}
