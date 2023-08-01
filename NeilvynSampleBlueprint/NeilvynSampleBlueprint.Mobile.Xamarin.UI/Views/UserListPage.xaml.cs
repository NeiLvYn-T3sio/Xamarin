using NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Views;
using System.Diagnostics.CodeAnalysis;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.UI.Views
{
    [ExcludeFromCodeCoverage]
    public partial class UserListPage 
    {
        public UserListPage()
        {
            InitializeComponent();
        }
    }

    public class UserListPageXaml : AppContentPageBase<UserListViewModel>
    {
    }
}