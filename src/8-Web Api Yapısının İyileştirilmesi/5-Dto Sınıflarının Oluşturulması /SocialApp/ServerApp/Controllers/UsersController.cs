using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Data;
using ServerApp.DTO;

namespace ServerApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly ISocialRepository _repository;
        public UsersController(ISocialRepository repository)
        {
            _repository = repository;
        }

         // api/users
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repository.GetUsers();

            var liste = new List<UserForListDTO>();

            foreach (var user in users)
            {
                liste.Add(new UserForListDTO() {
                    Id = user.Id,
                    UserName = user.UserName,
                    Gender = user.Gender
                });
            }

            return Ok(liste);
        }


        // api/users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repository.GetUser(id);
            return Ok(user);
        }
    }
}