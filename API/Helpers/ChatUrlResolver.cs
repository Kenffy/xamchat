
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ChatUrlResolver : IValueResolver<Chat, ChatDto, string>
    {
        private readonly IConfiguration _config;
        public ChatUrlResolver(IConfiguration config)
        {
            _config = config;

        }
        public string Resolve(Chat source, ChatDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.Media.DocumentUrl))
            {
                return _config["ApiUrl"] + "images/chats/" + source.Media.DocumentUrl;
            }

            return null;
        }
    }
}