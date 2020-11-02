using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Identity.Entities;

namespace Core.Entities
{
    public class Chat : BaseEntity
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UserId { get; set; }
        public int MediaId { get; set; }
        [NotMapped]
        public Media Media { get; set; }
    }
}