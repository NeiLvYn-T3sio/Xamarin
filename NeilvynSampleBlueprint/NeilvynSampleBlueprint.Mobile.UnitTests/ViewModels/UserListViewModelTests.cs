using NeilvynSampleBlueprint.Mobile.Common.Exceptions;
using NeilvynSampleBlueprint.Mobile.Models;
using NeilvynSampleBlueprint.Mobile.Xamarin.Common.ViewModels;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Navigation;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Services;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Web;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.UnitTests.ViewModels
{
    [TestFixture]
    public class UserListViewModelTests
    {
        private Mock<INavigationService> _navigationService;
        private Mock<IAppDialogService> _appDialogService;
        private Mock<IUserService> _userManagerMock;
        private Mock<ILogger<UserListViewModel>> _loggerMock;

        [SetUp]
        public void SetUp()
        {
            _navigationService = new Mock<INavigationService>();
            _appDialogService = new Mock<IAppDialogService>();
            _userManagerMock = new Mock<IUserService>();
            _loggerMock = new Mock<ILogger<UserListViewModel>>();
        }

        private UserListViewModel CreateViewModel()
        {
            return new UserListViewModel(_navigationService.Object, _appDialogService.Object, _userManagerMock.Object, _loggerMock.Object);
        }

        [Test]
        public void Ctor()
        {
            var viewModel = CreateViewModel();

            viewModel.BackCommand.AllowsMultipleExecutions.ShouldBe(false);
            viewModel.UserList.ShouldNotBeNull();
            viewModel.UserList.ShouldBeEmpty();
        }

        [Test]
        public async Task Initialize_UserListShouldContainAll_OnCall()
        {
            var viewModel = CreateViewModel();

            _userManagerMock.Setup(m => m.GetUsers())
                .ReturnsAsync(Enumerable.Repeat(new User(), 10));

            await viewModel.InitializeAsync(null);

            viewModel.UserList.Count.ShouldBe(10);

        }

        [Test]
        public async Task Initialize_IsOfflineDataShouldBeFalse_OnCall()
        {
            var viewModel = CreateViewModel();

            _userManagerMock.Setup(m => m.GetUsers())
                .ReturnsAsync(Enumerable.Repeat(new User(), 10));

            await viewModel.InitializeAsync(null);

            viewModel.IsOfflineData.ShouldBe(false);
        }

        

        [Test]
        public async Task Initialize_GetsFromDatabase_IfNoInternetConnection()
        {
            var viewModel = CreateViewModel();

            _userManagerMock.Setup(m => m.GetUsers())
                .Throws<NoInternetConnectivityException>();

            _userManagerMock.Setup(m => m.GetUsersFromDb())
                .ReturnsAsync(Enumerable.Repeat(new User(), 7));

            await viewModel.InitializeAsync(null);

            viewModel.UserList.Count.ShouldBe(7);
        }

        [Test]
        public async Task Initialize_IsOfflineDataShouldBeTrue_IfNoInternetConnection()
        {
            var viewModel = CreateViewModel();

            _userManagerMock.Setup(m => m.GetUsers())
                .Throws<NoInternetConnectivityException>();

            _userManagerMock.Setup(m => m.GetUsersFromDb())
                .ReturnsAsync(Enumerable.Repeat(new User(), 7));

            await viewModel.InitializeAsync(null);


            viewModel.IsOfflineData.ShouldBe(true);
        }

        [Test]
        public async Task Initialize_ShouldShowWarning_IfExceptionIsThrown()
        {
            var viewModel = CreateViewModel();

            _userManagerMock.Setup(m => m.GetUsers())
                .Throws<Exception>();


            await viewModel.InitializeAsync(null);

            _appDialogService.Verify(m=>m.ShowWarning(It.IsAny<string>()));
        }
    }
}
