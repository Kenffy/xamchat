namespace Core.Entities
{
    public class Media : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string AudioUrl { get; set; }
        public string DocumentUrl { get; set; }
    }
}