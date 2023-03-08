using BackEndLS.IServices;
using BackEndLS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndLS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("createUser")]
        public IActionResult CreateUser(Users users)
        {
            try
            {
                string response = _userServices.CreateUser(users);
                return Ok(new { message = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Ha ocurrido un error en el sistema, contactese con soporte." });
            }
            
        }

        
    }
}
