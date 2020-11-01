using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Controllers.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Chat, ChatDto>()
                .ForMember(m => m.ImageUrl, c => c.MapFrom(s => s.Media.ImageUrl))
                .ForMember(m => m.VideoUrl, c => c.MapFrom(s => s.Media.VideoUrl))
                .ForMember(m => m.AudioUrl, c => c.MapFrom(s => s.Media.AudioUrl))
                .ForMember(m => m.DocumentUrl, c => c.MapFrom<ChatUrlResolver>());
        }
    }
}