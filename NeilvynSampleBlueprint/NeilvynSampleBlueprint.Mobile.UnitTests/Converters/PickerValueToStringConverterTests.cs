using NeilvynSampleBlueprint.Mobile.Xamarin.Common.Converters;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace NeilvynSampleBlueprint.Mobile.UnitTests.Converters
{
    [TestFixture]
    public class PickerValueToStringConverterTests
    {
        [Test]
        public void Convert_Empty_ShouldBeStringEmpty()
        {
            var converter = new PickerValueToStringConverter();

            var result = converter.Convert(Mock.Of<IEmpty>(), null, null, null);
            
            result.ShouldBe(string.Empty);
        }
        
        [Test]
        public void Convert_EmptyPlaceholder_ShouldBeStringEmpty()
        {
            var converter = new PickerValueToStringConverter();

            var result = converter.Convert("[empty]", null, null, null);
            
            result.ShouldBe(string.Empty);
        }
        
        [Test]
        public void Convert_ShouldBeObjectToString()
        {
            var converter = new PickerValueToStringConverter();

            var result = converter.Convert("Test", null, null, null);
            
            result.ShouldBe("Test");
        }

        [Test]
        public void Convert_Null_ShouldBeStringEmpty()
        {
            var converter = new PickerValueToStringConverter();

            var result = converter.Convert(null, null, null, null);
            
            result.ShouldBe(string.Empty);
        }

        [Test]
        public void ConvertBack_ShouldBeNull()
        {
            var converter = new PickerValueToStringConverter();
            
            var result = converter.ConvertBack(It.IsAny<object>(), null, null, null);

            result.ShouldBe(null);
        }
    }
}