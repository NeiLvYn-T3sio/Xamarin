using NeilvynSampleBlueprint.Mobile.Xamarin.Common.Converters;
using NUnit.Framework;
using Shouldly;

namespace NeilvynSampleBlueprint.Mobile.UnitTests.Converters
{
    [TestFixture]
    public class BooleanNegateConverterTests
    {
        private BooleanNegateConverter CreateBooleanNegateConverter()
        {
            return new BooleanNegateConverter();
        }

        [TestCase(true, false)]
        [TestCase(false, true)]
        public void Convert(bool value, bool expectedResult)
        {
            var converter = CreateBooleanNegateConverter();

            var result = converter.Convert(value, null, null, null);

            result.ShouldBe(expectedResult);
        }
        
        [Test]
        public void Convert_Null()
        {
            var converter = CreateBooleanNegateConverter();

            var result = converter.Convert(null, null, null, null);

            result.ShouldBe(false);
        }

        [TestCase(true, false)]
        [TestCase(false, false)]
        public void ConvertBack(bool value, bool expectedResult)
        {
            var converter = CreateBooleanNegateConverter();

            var result = converter.ConvertBack(value, null, null, null);

            result.ShouldBe(expectedResult);
        }
    }
}
