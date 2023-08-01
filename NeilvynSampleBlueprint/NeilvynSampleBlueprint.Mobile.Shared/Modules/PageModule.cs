using Autofac;
using NeilvynSampleBlueprint.Mobile.Common.Constants;
using NeilvynSampleBlueprint.Mobile.Xamarin.Common.Dialogs;
using NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Navigation;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Views;
using NeilvynSampleBlueprint.Mobile.Xamarin.Services.Navigation;
using NeilvynSampleBlueprint.Mobile.Xamarin.UI.Views;
using NeilvynSampleBlueprint.Mobile.Xamarin.UI.Views.Dialogs;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Shared.Modules
{
    public class PageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PageResolver>().As<IPageResolver>().SingleInstance();
            builder.Register(c => PopupNavigation.Instance).As<IPopupNavigation>();
            builder.RegisterType<Xamarin.UI.App>().As<Xamarin.UI.App>().As<IMainPage>().SingleInstance();

            builder.RegisterType<MainPage>()
                .Named<Page>(ViewNames.MainPage)
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<UserListPage>()
                .Named<Page>(ViewNames.UserListPage)
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterType<UserListViewModel>().AsSelf();

            builder.RegisterType<LoginPage>()
                .Named<Page>(ViewNames.LoginPage)
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterType<LoginViewModel>().AsSelf();


            RegisterDialogs(builder);
        }

        private static void RegisterDialogs(ContainerBuilder builder)
        {
            builder.RegisterType<ConfirmDialog>().Named<DialogBase>(ViewNames.ConfirmDialog)
                .AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<ConfirmDialogModel>().AsSelf();

            builder.RegisterType<AlertDialog>().Named<DialogBase>(ViewNames.AlertDialog)
                .AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<AlertDialogModel>().AsSelf();

            builder.RegisterType<LoadingDialog>().Named<DialogBase>(ViewNames.LoadingDialog)
                .AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<LoadingDialogModel>().AsSelf();
        }
    }
}
