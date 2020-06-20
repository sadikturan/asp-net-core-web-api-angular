using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServerApp.DTO;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDTO model) 
        {
            var user = new User {
                UserName = model.UserName,
                Email = model.Email,
                Name = model.Name,
                Gender = model.Gender,
                Created = DateTime.Now,
                LastActive = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if(result.Succeeded)
            {
                return StatusCode(201);
            }
            return BadRequest(result.Errors);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
                return BadRequest(new { message = "username is incorrect" });

            var result = await _signInManager.CheckPasswordSignInAsync(user,model.Password,false);

            if(result.Succeeded)
            {
                // login
                return Ok(new {
                    token = "token...",
                    username = user.UserName
                });
            }
            return Unauthorized();
        }
    }
                
}