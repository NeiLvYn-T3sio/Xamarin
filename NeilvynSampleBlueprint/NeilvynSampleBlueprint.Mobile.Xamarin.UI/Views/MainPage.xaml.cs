using NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Views;
using System.Diagnostics.CodeAnalysis;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.UI.Views
{
    [ExcludeFromCodeCoverage]
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    [ExcludeFromCodeCoverage]
    public class MainPageXaml : AppContentPageBase<MainViewModel>
    {
    }
}
