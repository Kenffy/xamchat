using System;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace API.Dtos
{
    public class ChatDto
    {
        public int Id { get; set; }
        [Required]
        public string Sender { get; set; }
        [Required]
        public string Receiver { get; set; }
        [Required]
        public string Message { get; set; }
        public string CreatedOn { get; set; }
        [Required]
        public string UserId { get; set; }
        public string Username { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string AudioUrl { get; set; }
        public string DocumentUrl { get; set; }
    }
}