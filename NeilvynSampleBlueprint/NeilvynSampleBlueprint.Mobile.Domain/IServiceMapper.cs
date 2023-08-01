namespace NeilvynSampleBlueprint.Mobile.Domain
{
    public interface IServiceMapper
    {
        TDestination Map<TSource, TDestination>(TSource value);
        TDestination Map<TDestination>(object value);
    }
}