using System;
using Core.Entities;

namespace API.Dtos
{
    public class ChatDto
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }
        public string CreatedOn { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string AudioUrl { get; set; }
        public string DocumentUrl { get; set; }
    }
}