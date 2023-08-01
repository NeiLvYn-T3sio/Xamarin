using NeilvynSampleBlueprint.Mobile.Common.Localization;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Validations;
using System.Text.RegularExpressions;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.Validations
{
    public class PasswordValidation : IValidationRule<string>
    {
        public string ValidationMessage => AppResources.ValidationMessage_InvalidPasswordFormat;

        public bool Check(string value) => ValidatePassword(value);

        private static bool ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return true;
            }

            try
            {
                var hasMinimum8Chars = Regex.IsMatch(password, @".{8,}");
                var hasNumber = Regex.IsMatch(password, @"[0-9]+");
                var hasUpperChar = Regex.IsMatch(password, @"[A-Z]+");
                var hasLowerChar = Regex.IsMatch(password, @"[a-z]+");
                // OWASP accepted symbols (https://owasp.org/www-community/password-special-characters)
                var hasSymbols = Regex.IsMatch(password, @"[ !""#$%&'()*+,-./:;<=>?@[\]^_`{|}~]");

                return hasMinimum8Chars &&
                       hasNumber &&
                       hasUpperChar &&
                       hasLowerChar &&
                       hasSymbols;
            }
            catch
            {
                return false;
            }
        }
    }
}
