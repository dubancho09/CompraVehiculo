using AutoMapper;
using Core.Dto;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
