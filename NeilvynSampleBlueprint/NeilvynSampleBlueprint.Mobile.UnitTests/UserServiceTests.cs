using NeilvynSampleBlueprint.Mobile.Domain;
using NeilvynSampleBlueprint.Mobile.Domain.Persistance;
using NeilvynSampleBlueprint.Mobile.Models;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Web;
using NeilvynSampleBlueprint.Mobile.Xamarin.Services.Mapping;
using NeilvynSampleBlueprint.Mobile.Xamarin.Services.Web;
using Moq;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeilvynSampleBlueprint.Mobile.UnitTests
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserWebService> _userWebServiceMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private IServiceMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _userWebServiceMock = new Mock<IUserWebService>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapper = new ServiceMapper();
        }

        private UserService CreateUserService()
        {
            return new UserService(
                _userWebServiceMock.Object,
                _unitOfWorkMock.Object,
                _mapper);
        }

        [Test]
        public async Task GetUsers_ReturnUserList_OnCall()
        {
            var manager = CreateUserService();

            _userWebServiceMock.Setup(uwbs=>uwbs.GetUsers())
                .ReturnsAsync(Enumerable.Repeat(Mock.Of<UserDTO>(), 10));
            _unitOfWorkMock.Setup(uw => uw.Users).Returns(new Mock<IRepository<User>>().Object);

            var result = await manager.GetUsers();

            result.Count().ShouldBe(10);
        }

        [Test]
        public async Task GetUserFromDb_ReturnsUserList_OnCall()
        {
            var manager = CreateUserService();

            _unitOfWorkMock.Setup(uw=>uw.Users.GetAllAsync())
                .ReturnsAsync(new List<User>(Enumerable.Repeat(Mock.Of<User>(), 10)));

            var result = await manager.GetUsersFromDb();

            result.Count().ShouldBe(10);
        }
    }
}