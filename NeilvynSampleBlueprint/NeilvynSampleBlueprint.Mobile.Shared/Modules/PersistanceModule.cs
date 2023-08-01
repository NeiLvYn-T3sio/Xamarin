using Autofac;
using NeilvynSampleBlueprint.Mobile.Domain.Persistance;
using NeilvynSampleBlueprint.Mobile.Xamarin.Services.Persistance;

namespace NeilvynSampleBlueprint.Mobile.Shared.Modules
{
    public class PersistanceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<MobileDbContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
