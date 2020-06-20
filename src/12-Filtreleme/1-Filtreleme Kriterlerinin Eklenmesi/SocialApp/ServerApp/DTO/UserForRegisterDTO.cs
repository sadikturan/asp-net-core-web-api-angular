using System;
using System.ComponentModel.DataAnnotations;

namespace ServerApp.DTO
{
    public class UserForRegisterDTO
    {
        [Required(ErrorMessage="name gerekli bir alan.")]  
        [StringLength(50,MinimumLength=10)]
        public string Name { get; set; }
        [Required] 
        public string UserName { get; set; }
        [Required] 
        [EmailAddress]
        public string Email { get; set; }
        public string Gender { get; set; }
        [Required] 
        public string Password { get; set; }
        [Required] 
        public DateTime DateOfBirth { get; set; }
        [Required] 
        public string Country { get; set; }
        [Required] 
        public string City { get; set; }
    }
}