using AutoMapper;
using NeilvynSampleBlueprint.Mobile.Domain;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Services.Mapping
{
    public class ServiceMapper : IServiceMapper
    {
        private readonly Mapper _mapper;
        public MapperConfiguration Config { get; }

        public ServiceMapper()
        {
            Config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EntityDataObjectProfile>();
            });

            _mapper = new Mapper(Config);

            Config.AssertConfigurationIsValid();
        }


        public TDestination Map<TSource, TDestination>(TSource value)
        {
            return _mapper.Map<TSource, TDestination>(value);
        }

        public TDestination Map<TDestination>(object value)
        {
            return _mapper.Map<TDestination>(value);
        }
    }
}
