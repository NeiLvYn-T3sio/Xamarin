using Autofac;
using NeilvynSampleBlueprint.Mobile.Common.Constants;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Navigation;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.UI
{
    public partial class App : IMainPage
    {
        private INavigationService _navigationService;

        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public void SetLifetimeScope(ILifetimeScope instance)
        {
            _navigationService = instance.Resolve<INavigationService>();
            _navigationService.PushToNewRootPage(ViewNames.MainPage).Wait();
        }
    }
}
