namespace NeilvynSampleBlueprint.Mobile.Xamarin.Common.Validations
{
    public class StringValidatableObject : ValidatableObject<string>
    {
        public StringValidatableObject()
        {
            Value = string.Empty;
        }

        public bool HasValue => !string.IsNullOrWhiteSpace(Value);
    }
}
