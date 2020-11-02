using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Identity.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Chat, ChatDto>();
                /*.ForMember(m => m.ImageUrl, c => c.MapFrom(s => s.Media.ImageUrl))
                .ForMember(m => m.VideoUrl, c => c.MapFrom(s => s.Media.VideoUrl))
                .ForMember(m => m.AudioUrl, c => c.MapFrom(s => s.Media.AudioUrl))
                .ForMember(m => m.DocumentUrl, c => c.MapFrom<ChatUrlResolver>());*/
                
            CreateMap<ChatDto, Chat>();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<AppUser, UserDto>()
                .ForMember(m => m.FullName, u => u.MapFrom(x => x.FullName))
                .ForMember(m => m.Email, u => u.MapFrom(x => x.Email))
                .ForMember(m => m.PictureUrl, u => u.MapFrom<UserUrlResolver>());
        }
    }
}