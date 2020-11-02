using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using API.Dtos;
using AutoMapper;
using API.Errors;
using Microsoft.AspNetCore.Http;
using API.Helpers;
using API.Extensions;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Core.Identity.Entities;

namespace API.Controllers
{
    [Authorize]
    public class ChatsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IChatServices _chatServices;
        public ChatsController(UserManager<AppUser> userManager, IChatServices chatServices, IMapper mapper)
        {
            _chatServices = chatServices;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ChatDto>>> GetChats([FromQuery] ChatSpecParams chatParams)
        {
            var user = await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
            chatParams.me = user.Email;

            var totalchats = await _chatServices.GetTotalOfChatBySpecAsync(chatParams);
            var chats = await _chatServices.GetChatsByUserAsync(chatParams);

            var data = _mapper.Map<IReadOnlyList<Chat>, IReadOnlyList<ChatDto>>(chats);

            return Ok(new Pagination<ChatDto>(chatParams.PageIndex, chatParams.PageSize, totalchats, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ChatDto>> GetChat(int id)
        {
            var chat = await _chatServices.GetChatWithSpec(id);
            if (chat == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<Chat, ChatDto>(chat);
        }

        [HttpPost]
        public async Task<ActionResult<Chat>> SendChat(ChatDto chatDto)
        {
            var user = await _userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);

            var chat = _mapper.Map<ChatDto, Chat>(chatDto);
            chat.CreatedOn = DateTime.Today;
            chat.UserId = user.Id;

            var sendedChat = await _chatServices.SendChatAsync(chat);

            if (sendedChat == null) return BadRequest(new ApiResponse(400, "Problem while sending a chat"));

            return Ok(sendedChat);
        }

        [HttpDelete]
        public async Task<ActionResult<Chat>> DeleteChat(ChatDto chatDto)
        {
            var chat = await _chatServices.GetChatWithSpec(chatDto.Id);

            var deletedChat = await _chatServices.DeleteChatAsync(chat);

            if (deletedChat == null) return BadRequest(new ApiResponse(400, "Problem while deleting a chat"));

            return Ok(deletedChat);
        }
    }
}