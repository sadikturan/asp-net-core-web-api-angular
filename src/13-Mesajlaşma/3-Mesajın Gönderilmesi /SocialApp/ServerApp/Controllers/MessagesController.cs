using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Data;
using ServerApp.DTO;
using ServerApp.Helpers;
using System.Security.Claims;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    [ServiceFilter(typeof(LastActiveActionFilter))]
    [Authorize]
    [Route("api/users/{userId}/[controller]")]
    [ApiController]
    public class MessagesController: ControllerBase
    {
        private readonly ISocialRepository _repository;
        private readonly IMapper _mapper;

        public MessagesController(ISocialRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(int userId, MessageForCreateDTO messageForCreateDTO)
        {            
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            messageForCreateDTO.SenderId = userId;

            var recipient = await _repository.GetUser(messageForCreateDTO.RecipientId);

            if(recipient==null)
                return BadRequest("mesaj göndermek istediğiniz kullanıcı yok.");

            var message = _mapper.Map<Message>(messageForCreateDTO);

            _repository.Add(message);

            if(await _repository.SaveChanges())
            {
                var messageDTO = _mapper.Map<MessageForCreateDTO>(message);
                return Ok(messageDTO);
            }
            throw new System.Exception("error");
        }
    }
}