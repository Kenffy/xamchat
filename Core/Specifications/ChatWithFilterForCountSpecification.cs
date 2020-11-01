using Core.Entities;

namespace Core.Specifications
{
    public class ChatWithFilterForCountSpecification : BaseSpecification<Chat>
    {
        public ChatWithFilterForCountSpecification(ChatSpecParams chatParams): base(x =>
            (string.IsNullOrEmpty(chatParams.Search) || x.Message.ToLower().Contains(chatParams.Search)))
        {
            
        }
    }
}