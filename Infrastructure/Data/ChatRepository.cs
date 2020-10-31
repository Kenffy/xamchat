using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ChatRepository : IChatRepository
    {
        private readonly StoreContext _context;
        public ChatRepository(StoreContext context)
        {
            _context = context;

        }
        public async Task<Chat> GetChatByIdAsync(int id)
        {
            return await _context.Chats.Include(m => m.Media).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IReadOnlyList<Chat>> GetChatsAsync()
        {
            return await _context.Chats.Include(m => m.Media).ToListAsync();
        }

        public async Task<IReadOnlyList<Chat>> GetChatsByUserIdAsync(string userid)
        {
            return await _context.Chats.Include(c => c.UserId == userid).ToListAsync();
        }

        public async Task<IReadOnlyList<Media>> GetMediasAsync()
        {
            return await _context.Medias.ToListAsync();
        }
    }
}