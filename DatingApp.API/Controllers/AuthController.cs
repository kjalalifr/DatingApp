using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegister userForRegister)
        {
            // validate request
            userForRegister.Username=userForRegister.Username.ToLower();

            if (await _repo.UserExists(userForRegister.Username))
               return BadRequest("User already exist");

            var userToCreate=new User
            {
                UserName=userForRegister.Username
            };

            var createUser = await _repo.Register(userToCreate,userForRegister.Password);
            return StatusCode(201);
        }

    }
}