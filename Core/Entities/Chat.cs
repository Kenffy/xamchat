using System;

namespace Core.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UserId { get; set; }
        //public User AppUser { get; set; }
        //public int MediaId { get; set; }
        //public Media Media { get; set; }
    }
}