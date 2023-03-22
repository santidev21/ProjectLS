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
                return BadRequest(new { message = "A system error occurred while querying for the user details, contact support." });
            }
        }
        [HttpPost("userDetail")]
        public IActionResult setUserDetail(UserDetails Detail)
        {
            try
            {
                Response<UserDetails> response = _userServices.SetUserDetail(Detail);
                return Ok(new { message = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "A system error occurred while saving user detail, contact support." });
            }
        }
        [HttpGet("userProfilePic/{userId}")]
        public IActionResult getUserProfilePic(int userId)
        {
            try
            {
                Response<UserProfilePic> response = _userServices.GetUserProfilePic(userId);
                return Ok(new { message = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "A system error occurred while saving user profile pic, contact support." });
            }
        }
        [HttpPost("userProfilePic")]
        public IActionResult setUserProfilePic(UserProfilePic ProfilePic)
        {
            try
            {
                Response<UserProfilePic> response = _userServices.SetUserProfilePic(ProfilePic);
                return Ok(new { message = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "A system error occurred while saving user profile pic, contact support." });
            }
        }
        [HttpPut("userProfilePic")]
        public IActionResult updateUserProfilePic(UserProfilePic ProfilePic)
        {
            try
            {
                Response<UserProfilePic> response = _userServices.updateProfilePic(ProfilePic);
                return Ok(new { message = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "A system error occurred while updating user profile pic, contact support." });
            }
        }
    }
}
