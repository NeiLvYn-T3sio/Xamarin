using NeilvynSampleBlueprint.Mobile.Common.Exceptions;
using NeilvynSampleBlueprint.Mobile.Models;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Services;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Web;
using NeilvynSampleBlueprint.Mobile.Xamarin.Services.Web;
using Moq;
using NUnit.Framework;
using Shouldly;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.UnitTests.WebServices
{
    [TestFixture]
    public class UserWebServiceTests : WebServiceTestBase
    {
        private Mock<IUserApi> _userApiMock;
        private Mock<IConnectivity> _connectivityMock;
        private Mock<ISecuredStorage> _securedStorageMock;

        [SetUp]
        public void SetUp()
        {
            _userApiMock = new Mock<IUserApi>();
            _connectivityMock = new Mock<IConnectivity>();
            _securedStorageMock = new Mock<ISecuredStorage>();
        }

        private UserWebService CreateWebService()
        {
            return new UserWebService(_userApiMock.Object, _connectivityMock.Object, _securedStorageMock.Object);
        }

        [Test]
        public async Task GetUsers_ReturnsUserList_OnCall()
        {
            var webService = CreateWebService();

            _connectivityMock.Setup(c => c.IsInternetConnected).Returns(true);

            _userApiMock.Setup(m => m.GetUsers())
                .ReturnsAsync(Enumerable.Repeat(Mock.Of<UserDTO>(), 10));

            var result = await webService.GetUsers();

            result.Count().ShouldBe(10);
        }

        [Test]
        public void GetUsers_ThrowsServerError_OnApiException500()
        {
            var webService = CreateWebService();

            _connectivityMock.Setup(c => c.IsInternetConnected).Returns(true);

            _userApiMock.Setup(m => m.GetUsers())
                .Throws(CreateApiException(HttpStatusCode.InternalServerError));

            webService.GetUsers().ShouldThrow<ServerErrorException>();
        }
    }
}
