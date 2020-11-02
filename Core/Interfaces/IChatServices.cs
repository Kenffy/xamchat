using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IChatServices
    {
         Task<Chat> SendChatAsync(Chat chat);
         Task<Chat> DeleteChatAsync(Chat chat);
         Task<Chat> GetChatWithSpec(int id);
         Task<int> GetTotalOfChatBySpecAsync(ChatSpecParams chatParams);
         Task<IReadOnlyList<Chat>> GetChatsByUserAsync(ChatSpecParams chatParams);
    }
}