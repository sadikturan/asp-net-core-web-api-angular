using System;

namespace ServerApp.DTO
{
    public class ImagesForDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsProfile { get; set; }
    }
}