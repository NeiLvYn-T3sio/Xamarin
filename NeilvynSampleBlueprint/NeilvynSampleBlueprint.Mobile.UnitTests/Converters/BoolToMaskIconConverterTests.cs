using NeilvynSampleBlueprint.Mobile.Xamarin.UI.Converters;
using NeilvynSampleBlueprint.Mobile.Xamarin.UI.Resources;
using NUnit.Framework;
using Shouldly;

namespace NeilvynSampleBlueprint.Mobile.UnitTests.Converters
{
    [TestFixture]
    public class BoolToMaskIconConverterTests
    {
        private BoolToMaskIconConverter CreateBoolToMaskIconConverter()
        {
            return new BoolToMaskIconConverter();
        }

        [TestCase(true, FontAwesomeIcons.EyeSlash)]
        [TestCase(false, FontAwesomeIcons.Eye)]
        public void Convert(bool value, string expectedResult)
        {
            var boolToMaskIconConverter = CreateBoolToMaskIconConverter();

            var result = boolToMaskIconConverter.Convert(value, null, null, null);

            result.ShouldBe(expectedResult);
        }
        
        [Test]
        public void Convert_Null_ShouldBeEyeSlash()
        {
            var boolToMaskIconConverter = CreateBoolToMaskIconConverter();

            var result = boolToMaskIconConverter.Convert(null, null, null, null);

            result.ShouldBe(FontAwesomeIcons.EyeSlash);
        }

        [TestCase(FontAwesomeIcons.EyeSlash, true)]
        [TestCase("OtherIcons", false)]
        public void ConvertBack(string value, bool expectedResult)
        {
            var boolToMaskIconConverter = CreateBoolToMaskIconConverter();

            var result = boolToMaskIconConverter.ConvertBack(value, null, null, null);

            result.ShouldBe(expectedResult);
        }
    }
}
