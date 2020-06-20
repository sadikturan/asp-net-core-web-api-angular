using System.ComponentModel.DataAnnotations;

namespace ServerApp.DTO
{
    public class UserForUpdateDTO
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Introduction { get; set; }
        public string Hobbies { get; set; }
    }
}