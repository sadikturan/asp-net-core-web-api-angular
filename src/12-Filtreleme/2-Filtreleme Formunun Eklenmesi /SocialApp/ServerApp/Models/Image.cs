using System;

namespace ServerApp.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsProfile { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } 

    }
}