using AutoMapper;
using NeilvynSampleBlueprint.Mobile.Models;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.Services.Mapping
{
    public class EntityDataObjectProfile : Profile
    {
        public EntityDataObjectProfile()
        {
            CreateMap<User, UserDTO>();

            CreateMap<UserDTO, User>()
                .ForMember(d=>d.Id, o=>o.Ignore());

        }

    }
}
