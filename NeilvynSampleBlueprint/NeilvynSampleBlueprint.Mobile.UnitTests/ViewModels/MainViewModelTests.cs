using NeilvynSampleBlueprint.Mobile.Common.Constants;
using NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Navigation;
using Moq;
using NUnit.Framework;
using Shouldly;
using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.UnitTests.ViewModels
{
    [TestFixture]
    public class MainViewModelTests
    {
        private Mock<INavigationService> _navigationService;

        [SetUp]
        public void SetUp()
        {
            _navigationService = new Mock<INavigationService>();
        }

        private MainViewModel CreateViewModel()
        {
            return new MainViewModel(_navigationService.Object);
        }
        
        [Test]
        public void Ctor()
        {
            var viewModel = CreateViewModel();

            viewModel.GoToUserListCommand.AllowsMultipleExecutions.ShouldBe(false);
        }

        [Test]
        public async Task GoToUserListCommand()
        {
            var viewModel = CreateViewModel();

            await viewModel.GoToUserListCommand.ExecuteAsync();

            _navigationService.Verify(m=> m.PushAsync(ViewNames.UserListPage), Times.Once);
        }
    }
}
