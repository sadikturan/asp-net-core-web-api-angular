using System;

namespace ServerApp.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }

        public int RecipientId { get; set; }
        public User Recipient { get; set; }
        public string Text { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateRead { get; set; }

        public bool IsRead { get; set; }
        public bool SenderDeleted { get; set; }
        public bool RecipientDeleted { get; set; }

    }
}