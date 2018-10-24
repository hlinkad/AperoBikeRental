using System.Threading.Tasks;
using AperoRental.API.DataContexts;
using AperoRental.API.DataTransferObjects;
using AperoRental.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AperoRental.API.Controllers {

    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {
    
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo,IConfiguration config){
            _repo = repo;
            _config = config;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAdmin(RegisterDTO dto) {//later an object instead of plain strings
            //here comes validation of a request later
            //consider usernames Denis and denis as the same, so far it's not the same
            //dto is initialized from the body of an http request
            string username = dto.UserName;
            string password = dto.Password;
            string email = dto.Email;

            if(await _repo.AdminExists(username)){
                return BadRequest("Username already exists.");
            }
            Admin adminToCreate = new Admin {UserName = username, Email = email};
            Admin createdAdmin = await _repo.RegisterAdmin(adminToCreate,password);
           return StatusCode(201);
        }  

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto) {
           
           string username = dto.UserName;
           string password = dto.Password;
           Admin thatWantsToLogin = await _repo.Login(username,password);

           if(thatWantsToLogin == null){
               return Unauthorized();
           }
         
            ITokenGenerator generator = new TokenGenerator(thatWantsToLogin.Id,username,_config.GetSection("AppSettings:Token").Value);
            var token = generator.GenerateTokenForClient();

           return Ok( new {
               token = generator.WriteToken(token) //don't send token as plain text in production, encrypt later in https and certificates
           });
        }
    }

}