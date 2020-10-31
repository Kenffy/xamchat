using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IChatRepository
    {
        Task<Chat> GetChatByIdAsync(int id);
        Task<IReadOnlyList<Chat>> GetChatsAsync();
        Task<IReadOnlyList<Media>> GetMediasAsync();
        Task<IReadOnlyList<Chat>> GetChatsByUserIdAsync(string userid);
    }
}