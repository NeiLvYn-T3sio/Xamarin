using Autofac;
using NeilvynSampleBlueprint.Mobile.Xamarin.Common;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Navigation;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Services;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Web;
using NeilvynSampleBlueprint.Mobile.Xamarin.Services;
using NeilvynSampleBlueprint.Mobile.Xamarin.Services.Navigation;
using NeilvynSampleBlueprint.Mobile.Xamarin.Services.Web;

namespace NeilvynSampleBlueprint.Mobile.Shared.Modules
{
    public class XamarinServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            
            builder.RegisterType<TaskRunner>().As<ITaskRunner>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            builder.RegisterType<AppDialogService>().As<IAppDialogService>().SingleInstance();
            builder.RegisterType<AppInformationService>().As<IAppInformationService>().SingleInstance();
            builder.RegisterType<SecuredStorage>().As<ISecuredStorage>().SingleInstance();
            builder.RegisterType<Connectivity>().As<IConnectivity>().SingleInstance();
            builder.RegisterType<UserWebService>().As<IUserWebService>().SingleInstance();
        }
    }
}