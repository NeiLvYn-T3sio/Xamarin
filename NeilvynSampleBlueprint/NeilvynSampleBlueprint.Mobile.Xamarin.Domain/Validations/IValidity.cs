namespace NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Validations
{
    public interface IValidity
    {
        ValidationState ValidationState { get; set; }

        bool IsValid { get; set; }
    }
}
