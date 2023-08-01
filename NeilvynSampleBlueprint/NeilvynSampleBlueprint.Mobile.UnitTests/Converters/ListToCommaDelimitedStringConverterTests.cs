using NeilvynSampleBlueprint.Mobile.Xamarin.Common.Converters;
using NUnit.Framework;
using Shouldly;

namespace NeilvynSampleBlueprint.Mobile.UnitTests.Converters
{
    [TestFixture]
    public class ListToCommaDelimitedStringConverterTests
    {
        [Test]
        public void Convert_ShouldBeCommaDelimitedString()
        {
            var converter = new ListToCommaDelimitedStringConverter();

            var result = converter.Convert(new[] { "this", "is", "a", "test" }, null, null, null);
            
            result.ShouldBe("this, is, a, test");
        }

        [Test]
        public void Convert_Null_ShouldBeStringEmpty()
        {
            var converter = new ListToCommaDelimitedStringConverter();

            var result = converter.Convert(null, null, null, null);
            
            result.ShouldBe(string.Empty);
        }

        [Test]
        public void ConvertBack_ShouldBeTheSameObject()
        {
            var converter = new ListToCommaDelimitedStringConverter();

            var newObject = new object();
            
            var result = converter.ConvertBack(newObject, null, null, null);

            result.ShouldBe(newObject);
        }
    }
}