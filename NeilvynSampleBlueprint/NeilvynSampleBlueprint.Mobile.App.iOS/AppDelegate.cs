using System.Diagnostics.CodeAnalysis;
using Autofac;
using NeilvynSampleBlueprint.Mobile.App.Common.Constants;
using NeilvynSampleBlueprint.Mobile.App.Shared;
using Foundation;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using UIKit;

namespace NeilvynSampleBlueprint.Mobile.App.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    [SuppressMessage("ReSharper", "PartialTypeWithSinglePart")]
    [SuppressMessage("ReSharper", "RedundantNameQualifier")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private Forms.App _app;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Rg.Plugins.Popup.Popup.Init();
            AppCenter.Start(AppConstants.AppCenterIosKey, typeof(Analytics), typeof(Crashes));
            global::Xamarin.Forms.Forms.Init();


            InitializeContainer();

            LoadApplication(_app);

            return base.FinishedLaunching(app, options);
        }

        private void InitializeContainer()
        {
            AutofacBootstrapper.RegisterAutofacModule();

            _app = AutofacBootstrapper.Instance.Resolve<Forms.App>();
            _app.SetLifetimeScope(AutofacBootstrapper.Instance);
        }
    }
}
