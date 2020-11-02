using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace Infrastructure.Data.Services
{
    public class ChatServices : IChatServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChatServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Chat> GetChatWithSpec(int id)
        {
            var spec = new ChatWithMediaSpecification(id);
            return await _unitOfWork.Repository<Chat>().GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<Chat>> GetChatsByUserAsync(ChatSpecParams chatParams)
        {
            var spec = new ChatWithMediaSpecification(chatParams);
            return await _unitOfWork.Repository<Chat>().ListAsync(spec);
        }

        public async Task<int> GetTotalOfChatBySpecAsync(ChatSpecParams chatParams)
        {
            var countSpec = new ChatWithFilterForCountSpecification(chatParams);
            return await _unitOfWork.Repository<Chat>().CountAsync(countSpec);
        }

        public async Task<Chat> SendChatAsync(Chat chat)
        {
            _unitOfWork.Repository<Chat>().Add(chat);
            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;
            
            return chat;
        }

        public async Task<Chat> DeleteChatAsync(Chat chat)
        {
            _unitOfWork.Repository<Chat>().Delete(chat);
            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;
            
            return chat;
        }
    }
}