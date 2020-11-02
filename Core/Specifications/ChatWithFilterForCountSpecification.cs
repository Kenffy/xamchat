using Core.Entities;

namespace Core.Specifications
{
    public class ChatWithFilterForCountSpecification : BaseSpecification<Chat>
    {
        public ChatWithFilterForCountSpecification(ChatSpecParams chatParams): base(x =>
            ((string.IsNullOrEmpty(chatParams.me) || x.Sender == chatParams.me) &&
             (string.IsNullOrEmpty(chatParams.wu) || x.Receiver == chatParams.wu)) ||
            ((string.IsNullOrEmpty(chatParams.me) || x.Receiver == chatParams.me) &&
             (string.IsNullOrEmpty(chatParams.wu) || x.Sender == chatParams.wu)) &&
            (string.IsNullOrEmpty(chatParams.Search) || x.Message.ToLower().Contains(chatParams.Search)))
        {
            
        }
    }
}