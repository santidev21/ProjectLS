using BackEndLS.IServices;
using BackEndLS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
                return BadRequest(new { message = "A system error has occurred, contact support." });
            }
            
        }

        [HttpGet("petTypes")]
        public IActionResult getPetTypes() 
        {
            Response<List<PetType>> response = new Response<List<PetType>>();
            try
            {
                response = _userServices.GetPetTypes();
                return Ok(response);
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
                response.Value = null;

                return BadRequest(response);
            }
        }
        [HttpGet("race/{PetTypeId}")]
        public IActionResult getRaces(int PetTypeId)
        {
            Response<List<Race>> response = new Response<List<Race>>();

            try
            {
                response = _userServices.GetRaces(PetTypeId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "A system error occurred while querying for the race, contact support." });
            }
        }
        [HttpGet("gender")]
        public IActionResult getGenders()
        {
            Response<List<Gender>> response = new Response<List<Gender>>();

            try
            {
                response = _userServices.GetGenders();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "A system error occurred while querying for the gender list, contact support." });
            }
        }
        [HttpGet("userDetails/{userId}")]
        public IActionResult getUserDetails(int userId)
        {
            try
            {
                List <UserDetails> response = _userServices.GetUserDetails(userId);
                return Ok(new { message = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "A system error occurred while querying for the gender list, contact support." });
            }
        }

    }
}
