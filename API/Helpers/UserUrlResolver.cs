using API.Dtos;
using AutoMapper;
using Core.Identity.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class UserUrlResolver : IValueResolver<AppUser, UserDto, string>
    {
        private readonly IConfiguration _config;
        public UserUrlResolver(IConfiguration config)
        {
            _config = config;

        }
        public string Resolve(AppUser source, UserDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + "images/profiles/" + source.PictureUrl;
            }

            return null;
        }
    }
}