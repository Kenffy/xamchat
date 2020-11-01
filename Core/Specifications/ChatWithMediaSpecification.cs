using Core.Entities;

namespace Core.Specifications
{
    public class ChatWithMediaSpecification : BaseSpecification<Chat>
    {
        public ChatWithMediaSpecification(ChatSpecParams chatParams): base(x =>
            (string.IsNullOrEmpty(chatParams.Search) || x.Message.ToLower().Contains(chatParams.Search)))
        {
            AddInclude(x => x.Media);
            AddOrderBy(x => x.CreatedOn);
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
                        AddOrderBy(x => x.CreatedOn);
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