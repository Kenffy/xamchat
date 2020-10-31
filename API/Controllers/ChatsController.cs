using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatsController : ControllerBase
    {
        private readonly IChatRepository _repo;
        public ChatsController(IChatRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Chat>>> GetChats()
        {
            var chats = await _repo.GetChatsAsync();
            return Ok(chats);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chat>> GetChat(int id)
        {
            var chat = await _repo.GetChatByIdAsync(id);
            return Ok(chat);
        }

        [HttpGet("medias")]
        public async Task<ActionResult<Chat>> GetMedias()
        {
            var medias = await _repo.GetMediasAsync();
            return Ok(medias);
        }
    }
}