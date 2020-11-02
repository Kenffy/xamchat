using Core.Entities;

namespace Core.Specifications
{
    public class ChatWithMediaSpecification : BaseSpecification<Chat>
    {
        public ChatWithMediaSpecification(ChatSpecParams chatParams): base(x =>
            ((string.IsNullOrEmpty(chatParams.me) || x.Sender == chatParams.me) &&
             (string.IsNullOrEmpty(chatParams.wu) || x.Receiver == chatParams.wu)) ||
            ((string.IsNullOrEmpty(chatParams.me) || x.Receiver == chatParams.me) &&
             (string.IsNullOrEmpty(chatParams.wu) || x.Sender == chatParams.wu)) &&
            (string.IsNullOrEmpty(chatParams.Search) || x.Message.ToLower().Contains(chatParams.Search)))
        {
            AddOrderBy(x => x.Id);
            ApplyPaging(chatParams.PageSize * (chatParams.PageIndex -1), chatParams.PageSize);

            if(!string.IsNullOrEmpty(chatParams.Sort))
            {
                switch(chatParams.Sort)
                {
                    case "idAsc":
                        AddOrderBy(c => c.Id);
                        break;
                    case "idDesc":
                        AddOrderByDescending(c => c.Id);
                        break;
                    default:
                        AddOrderBy(x => x.Id);
                        break;
                }
            }
        }

        public ChatWithMediaSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Media);
        }
    }
}