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
            try {
                Response<Users> response = _userServices.CreateUser(users);
                return Ok(response);
            } catch (Exception ex)
            {
                Response<Users> response = new Response<Users>(false, "C- There was an error trying to create the user, please contact support.", users);
                return BadRequest(response);
            }            
        }

        [HttpGet("petTypes")]
        public IActionResult getPetTypes() 
        {            
            try
            {
                Response<List<PetType>> response = _userServices.GetPetTypes();
                return Ok(response);
            }
            catch (Exception ex)
            {
                Response<List<PetType>> response = new Response<List<PetType>>(false, "C- There was an error trying to get the pet list, please contact support.", null);
                return BadRequest(response);
            }
        }
        [HttpGet("race/{PetTypeId}")]
        public IActionResult getRaces(int PetTypeId)
        {            
            try
            {
                Response<List<Race>> response = _userServices.GetRaces(PetTypeId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Response<List<Race>> response = new Response<List<Race>>(false, "C- There was an error trying to get the races, please contact support.", null);
                return BadRequest(response);
            }
        }
        [HttpGet("gender")]
        public IActionResult getGenders()
        {            
            try
            {
                Response<List<Gender>> response = _userServices.GetGenders();
                return Ok(response);
            }
            catch (Exception ex)
            {
                Response<List<Gender>> response = new Response<List<Gender>>(false, "C- There was an error trying to get the genders, please contact support.", null);
                return BadRequest(response);
            }
        }
        [HttpGet("userDetails/{userId}")]
        public IActionResult getUserDetails(int userId)
        {            
            try
            {
                Response<List<UserDetails>> response = _userServices.GetUserDetails(userId);
                return Ok(new { message = response });
            }
            catch (Exception ex)
            {
                Response<List<UserDetails>> response = new Response<List<UserDetails>>(false, "C- There was an error trying to get the user details, please contact support.", null);
                return BadRequest(response);
            }
        }
        [HttpPost("userDetail")]
        public IActionResult setUserDetail(UserDetails Detail)
        {
            try
            {
                Response<UserDetails> response = _userServices.SetUserDetail(Detail);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Response<UserDetails> response = new Response<UserDetails>(false, "C- There was an error trying to set the user details, please contact support.", null);
                return BadRequest(response);
            }
        }
        [HttpGet("userProfilePic/{userId}")]
        public IActionResult getUserProfilePic(int userId)
        {
            try
            {
                Response<UserProfilePic> response = _userServices.GetUserProfilePic(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Response<UserProfilePic> response = new Response<UserProfilePic>(false, "C- There was an error trying to get the user profile pic, please contact support.", null);
                return BadRequest(response);
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
                Response<UserProfilePic> response = new Response<UserProfilePic>(false, "C- There was an error trying to set the user profile pic, please contact support.", null);
                return BadRequest(response);
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
                Response<UserProfilePic> response = new Response<UserProfilePic>(false, "C- There was an error trying to update the user profile pic, please contact support.", null);
                return BadRequest(response);
            }
        }
    }
}
