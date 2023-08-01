using NeilvynSampleBlueprint.Mobile.Models;
using NeilvynSampleBlueprint.Mobile.Xamarin.Services.Mapping;
using NUnit.Framework;
using Shouldly;

namespace NeilvynSampleBlueprint.Mobile.UnitTests
{
    [TestFixture]
    public class ServiceMapperTests
    {    
        private ServiceMapper CreateServiceMapper()
        {
            return new ServiceMapper();
        }
        
        [Test]
        public void TestConfig()
        {
            var serviceMapper = CreateServiceMapper();
            serviceMapper.Config.AssertConfigurationIsValid();
        }

        [Test]
        public void Map_Contract()
        {
            var serviceMapper = CreateServiceMapper();
            var result = serviceMapper.Map<User>(new UserDTO());

            result.ShouldNotBeNull();
        }

        [Test]
        public void Map_Object()
        {
            var serviceMapper = CreateServiceMapper();
            var result = serviceMapper.Map<UserDTO>(new User());

            result.ShouldNotBeNull();
        }
    }
}