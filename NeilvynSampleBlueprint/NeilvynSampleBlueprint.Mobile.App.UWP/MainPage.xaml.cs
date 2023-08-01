using Autofac;
using NeilvynSampleBlueprint.Mobile.App.Shared;

namespace NeilvynSampleBlueprint.Mobile.App.UWP
{
    public sealed partial class MainPage
    {
        private Forms.App _app;

        public MainPage()
        {
            this.InitializeComponent();

            InitializeContainer();

            LoadApplication(_app);
        }

        private void InitializeContainer()
        {
            AutofacBootstrapper.RegisterAutofacModule();

            _app = AutofacBootstrapper.Instance.Resolve<Forms.App>();
            _app.SetLifetimeScope(AutofacBootstrapper.Instance);
        }
    }
}
