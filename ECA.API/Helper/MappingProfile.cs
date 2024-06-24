using AutoMapper;

namespace ECA.API.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            CreateMap<ComputerUser, ComputerUserDto>().ReverseMap();
        }
    }
}
