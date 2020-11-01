using Core.Entities;

namespace Core.Specifications
{
    public class ChatWithMediaSpecification : BaseSpecification<Chat>
    {
        public ChatWithMediaSpecification()
        {
            AddInclude(x => x.Media);
        }

        public ChatWithMediaSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Media);
        }
    }
}