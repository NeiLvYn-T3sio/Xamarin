using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.ViewModels;
using System;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Application = Xamarin.Forms.Application;
using NavigationPage = Xamarin.Forms.NavigationPage;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Views
{
    [ExcludeFromCodeCoverage]
    public abstract class AppContentPageBase : ContentPage, IViewModelTypeExposed
    {
        protected AppContentPageBase()
        {
            //Uncomment this if you need to implement custom navigation bar.
            //Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, true);
            BackgroundColor = (Color)Application.Current.Resources["PrimaryPageBackgroundColor"];
        }

        protected override async void OnAppearing()
        {
            if (this.BindingContext is IViewModel viewModel)
            {
                await viewModel.InitializeAsync(null);
                viewModel.Subscribe();
            }
        }

        protected override void OnDisappearing()
        {
            if (this.BindingContext is IViewModel viewModel)
            {
                viewModel.Unsubscribe();
                viewModel.CleanUp();
            }
        }

        protected void SetUseSafeArea()
        {
            On<iOS>().SetUseSafeArea(true);
        }

        public abstract Type ViewModelType { get; }
    }

    [ExcludeFromCodeCoverage]
    public abstract class AppContentPageBase<T> : AppContentPageBase where T : IViewModel
    {
        public override Type ViewModelType => typeof(T);
    }
}
