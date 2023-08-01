namespace NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Validations
{
    public interface IValidationRule<in T>
    {
        string ValidationMessage { get; }
        bool Check(T value);
    }
}
