using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Autofac;
using NeilvynSampleBlueprint.Mobile.Shared;
using NeilvynSampleBlueprint.Mobile.Common.Constants;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Diagnostics.CodeAnalysis;
using Essentials = Xamarin.Essentials;
using Serilog;

namespace NeilvynSampleBlueprint.Mobile.App.Droid
{
    [Activity(Label = "NeilvynSampleBlueprint.Mobile.App", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    [SuppressMessage("ReSharper", "RedundantNameQualifier")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private Xamarin.UI.App _app;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AppCenter.Start(AppConstants.AppCenterAndroidKey,typeof(Analytics), typeof(Crashes));
            Rg.Plugins.Popup.Popup.Init(this);
            Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            UserDialogs.Init(this);

            InitializeContainer();

            // ToDo: Wrap whole application in a try catch and add a Fatal log. Ideally, you could move the CloseAndFlush in the finally block.
            LoadApplication(_app);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            Log.CloseAndFlush();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void InitializeContainer()
        {
            AutofacBootstrapper.RegisterAutofacModule();

            _app = AutofacBootstrapper.Instance.Resolve<Xamarin.UI.App>();
            _app.SetLifetimeScope(AutofacBootstrapper.Instance);
        }
    }
}