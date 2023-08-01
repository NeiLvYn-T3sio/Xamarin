using Autofac;
using NeilvynSampleBlueprint.Mobile.Domain.Persistance;

#if __ANDROID__
using NeilvynSampleBlueprint.Mobile.App.Droid.Database;
#elif __IOS__
using NeilvynSampleBlueprint.Mobile.App.iOS.Database;
#else
using NeilvynSampleBlueprint.Mobile.App.UWP.Database;
#endif

namespace NeilvynSampleBlueprint.Mobile.Shared.Modules
{
    public class PlatformModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

#if __ANDROID__
            builder.RegisterType<DatabaseFactoryDroid>().As<IDatabaseFactory>().SingleInstance();
#elif __IOS__
            builder.RegisterType<DatabaseFactoryIos>().As<IDatabaseFactory>().SingleInstance();
#else
            builder.RegisterType<DatabaseFactoryUwp>().As<IDatabaseFactory>().SingleInstance();
#endif
        }
    }
}
