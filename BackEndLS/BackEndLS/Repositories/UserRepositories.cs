using BackEndLS.IRepositories;
using BackEndLS.Models;
using BackEndLS.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndLS.Repositories
{
    public class UserRepositories: IUserRepositories
    {
        private readonly LSContext _context;
        public UserRepositories(LSContext context)
        {
            _context = context;
        }

        public Response<Users> CreateUser(Users users)
        {
            try
            {
                _context.Add(users);
                _context.SaveChanges();
                Response<Users> response = new Response<Users>(true, "User created sucessfully", users);
                return response;
            }
            catch (Exception ex)
            {
                Response<Users> response = new Response<Users>(false, "R - An error occurred while trying to access the database to create user. Please contact support", null);
                return response;
            }
        }
        public bool ValidateUser(string username)
        {
            return _context.User.Where(x => x.UserName == username).ToList().Count() > 0 ? false : true;
        }

        public bool ValidateEmail(string email)
        {
            return _context.User.Where(x => x.Email == email).ToList().Count() > 0 ? false : true;
        }

        // Methods for the register
        public Response<List<PetType>> GetPetTypes() 
        {
            try
            {
                List<PetType> petTypes = _context.PetType.ToList();
                Response<List<PetType>> response = new Response<List<PetType>>(true, "List of pet types obtained successfully", petTypes);
                return response;
            }
            catch (Exception ex)
            {
                Response<List<PetType>> response = new Response<List<PetType>>(false, "R - An error occurred while trying to access the database to  get pet types. Please contact support", null);
                return response;
            }
            
        }
        public Response<List<Race>> GetRaces(int PetTypeId)
        {            
            try
            {
                List<Race> petTypes = _context.Race.Where(x => x.PetTypeId == PetTypeId).ToList();
                Response<List<Race>> response = new Response<List<Race>>(true, "List of successfully obtained races", petTypes);
                return response;
            }
            catch (Exception)
            {
                Response<List<Race>> response = new Response<List<Race>>(false, "R - An error occurred while trying to access the database to get races. Please contact support", null);
                return response;
            }
        }

        public Response<List<Gender>> GetGenders() 
        {            
            try
            {
                List<Gender> petTypes = _context.Gender.ToList();
                Response<List<Gender>> response = new Response<List<Gender>>(true, "List of genders obtained successfully",petTypes);
                return response;
            }
            catch (Exception)
            {
                Response<List<Gender>> response = new Response<List<Gender>>(false, "R - An error occurred while trying to access the database to get genders. Please contact support", null);
                return response;
            }
        }

        public Response<List<UserDetails>> GetUserDetails(int UserId) 
        {            
            try
            {
                List<UserDetails> userDetail = _context.UserDetails.Where(x => x.UserId == UserId).ToList();
                Response<List<UserDetails>> response = new Response<List<UserDetails>>(true, "User detail successfully obtained", userDetail);
                return response;
            }
            catch (Exception)
            {
                Response<List<UserDetails>> response = new Response<List<UserDetails>>(false, "R - An error occurred while trying to access the database to get user details. Please contact support", null);
                return response;
            }
            
        }
        public Response<UserDetails> SetUserDetail(UserDetails Detail)
        {
            try
            {
                _context.Add(Detail);
                _context.SaveChanges();
                Response<UserDetails> response = new Response<UserDetails>(true, "Details saved successfully", Detail);
                return response;

            }
            catch (Exception ex)
            {
                Response<UserDetails> response = new Response<UserDetails>(false, "R - An error occurred while trying to access the database to save user details. Please contact support", null);
                return response;
            }           
        }
        public Response<UserProfilePic> GetUserProfilePic(int UserId) 
        {
            
            try
            {
                UserProfilePic UserPic = _context.UserProfilePic.Where(x => x.UserId == UserId).FirstOrDefault();
                Response<UserProfilePic> response = new Response<UserProfilePic>(true, "User picture obtained successfully", UserPic);
                return response;
            }
            catch (Exception ex)
            {
                Response<UserProfilePic> response = new Response<UserProfilePic>(false, "R - An error occurred while trying to access the database to get user profile picture. Please contact support", null);
                return response;
            }
        }
        public Response<UserProfilePic> SetUserProfilePic(UserProfilePic ProfilePic)
        {
            try
            {
                _context.Add(ProfilePic);
                _context.SaveChanges();
                Response<UserProfilePic> response = new Response<UserProfilePic>(true, "User profile picture added succesfull!", ProfilePic);
                return response;
            }
            catch (Exception)
            {
                Response<UserProfilePic> response = new Response<UserProfilePic>(false, "R - An error occurred while trying to access the database to add user profile picture. Please contact support", null);
                return response;
            }
        }
        public Response<UserProfilePic> updateProfilePic(UserProfilePic ProfilePic)
        {
            try
            {
                _context.SaveChanges();
                Response<UserProfilePic> response = new Response<UserProfilePic>(true, "User profile picture updated succesfull!", ProfilePic);
                return response;
            }
            catch (Exception)
            {
                Response<UserProfilePic> response = new Response<UserProfilePic>(false, "R - An error occurred while trying to access the database to update user profile picture. Please contact support", null);
                return response;
            }
        }
    }
}
