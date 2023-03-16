﻿using BackEndLS.IServices;
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
                return BadRequest(new { message = "A system error has occurred, contact support." });
            }
            
        }

        // Get the pet type list
        [HttpGet("petTypes")]
        public IActionResult getPetTypes() 
        {
            try
            {
                List<PetType> response = _userServices.GetPetTypes();
                return Ok(new { message = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "A system error occurred while querying for the type of pet, contact support." });
            }
        }
        [HttpGet("race/{PetTypeId}")]
        public IActionResult getRaces(int PetTypeId)
        {
            try
            {
                List<Race> response = _userServices.GetRaces(PetTypeId);
                return Ok(new { message = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "A system error occurred while querying for the race, contact support." });
            }
        }
        
    }
}
