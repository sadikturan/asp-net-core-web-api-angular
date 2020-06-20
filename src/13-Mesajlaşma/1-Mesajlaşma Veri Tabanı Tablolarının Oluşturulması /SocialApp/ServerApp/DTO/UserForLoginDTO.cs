using System.ComponentModel.DataAnnotations;

namespace ServerApp.DTO
{
    public class UserForLoginDTO
    {
        [Required]         
         public string UserName { get; set; }
        [Required]      
         public string Password { get; set; }
    }
}