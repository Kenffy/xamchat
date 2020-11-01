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

namespace API.Controllers
{
    public class ChatsController : BaseApiController
    {
        private readonly IRepository<Chat> _chatrepo;
        private readonly IRepository<Media> _mediarepo;
        private readonly IMapper _mapper;
        public ChatsController(IRepository<Chat> chatrepo, IRepository<Media> mediarepo, IMapper mapper)
        {
            _mapper = mapper;
            _mediarepo = mediarepo;
            _chatrepo = chatrepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ChatDto>>> GetChats()
        {
            var spec = new ChatWithMediaSpecification();
            var chats = await _chatrepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Chat>, IReadOnlyList<ChatDto>>(chats));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ChatDto>> GetChat(int id)
        {
            var spec = new ChatWithMediaSpecification(id);
            var chat = await _chatrepo.GetEntityWithSpec(spec);

            if(chat == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Chat, ChatDto>(chat);
        }

        [HttpGet("medias")]
        public async Task<ActionResult<IReadOnlyList<Media>>> GetMedias()
        {
            var medias = await _mediarepo.ListAllAsync();
            return Ok(medias);
        }
    }
}