using NeilvynSampleBlueprint.Mobile.Xamarin.Common.Converters;
using NUnit.Framework;
using Shouldly;
using System;

namespace NeilvynSampleBlueprint.Mobile.UnitTests.Converters
{
    [TestFixture]
    public class NullableDateToStringConverterTests
    {
        [Test]
        public void Convert_ShouldBeDateTodayToString()
        {
            var converter = new NullableDateToStringConverter();

            var result = converter.Convert(DateTime.Today, null, null, null);
            
            result.ShouldBe($"{DateTime.Today}");
        }

        [Test]
        public void Convert_Null_ShouldBeStringEmpty()
        {
            var converter = new NullableDateToStringConverter();

            var result = converter.Convert(null, null, null, null);
            
            result.ShouldBe(string.Empty);
        }

        [Test]
        public void ConvertBack_ShouldBeDateToday()
        {
            var converter = new NullableDateToStringConverter();
            
            var result = converter.ConvertBack($"{DateTime.Today}", null, null, null);

            result.ShouldBe(DateTime.Today);
        }

    }
}