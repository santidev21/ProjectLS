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

        public void CreateUser(Users users)
        {
            _context.Add(users);
            _context.SaveChanges();
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
            Response<List<PetType>> response = new Response<List<PetType>>();

            List<PetType> petTypes = _context.PetType.ToList();

            response.Success = true;
            response.Value = petTypes;
            response.Message = "List of pet types obtained successfully";


            return response;
        }
        public Response<List<Race>> GetRaces(int PetTypeId)
        {
            Response<List<Race>> response = new Response<List<Race>>();

            List<Race> petTypes = _context.Race.Where(x => x.PetTypeId == PetTypeId).ToList();

            response.Success = true;
            response.Value = petTypes;
            response.Message = "List of successfully obtained races";

            return response;

        }

        public Response<List<Gender>> GetGenders() {

            Response<List<Gender>> response = new Response<List<Gender>>();

            List<Gender> petTypes = _context.Gender.ToList();

            response.Success = true;
            response.Value = petTypes;
            response.Message = "List of genders obtained successfully";

            return response;
        }

        public List<UserDetails> GetUserDetails(int UserId) { return _context.UserDetails.Where(x => x.UserId == UserId).ToList(); }
        public Response<UserDetails> SetUserDetail(UserDetails Detail)
        {
            Response<UserDetails> response = new Response<UserDetails>();
            try
            {
                _context.Add(Detail);
                _context.SaveChanges();

                response.Success = true;
                response.Value = Detail;
                response.Message = "Details saved successfully";
                return response;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Value = Detail;
                response.Message = "Error saving user detail successfully";
                return response;
            }           
        }
        public Response<UserProfilePic> GetUserProfilePic(int UserId) 
        {
            Response<UserProfilePic> response = new Response<UserProfilePic>();

            UserProfilePic UserPic= _context.UserProfilePic.Where(x => x.UserId == UserId).FirstOrDefault();
            if (UserPic != null)
            {
                response.Success = true;
                response.Message = "User pic obtained successfully";
            }
            else
            {
                response.Success = false;
                response.Message = "Error getting user image";
            }
            response.Value = UserPic;
            return response;
        }
        public Response<UserProfilePic> SetUserProfilePic(UserProfilePic ProfilePic)
        {
            Response<UserProfilePic> response = new Response<UserProfilePic>();
            try
            {
                _context.Add(ProfilePic);
                _context.SaveChanges();

                response.Success = true;
                response.Message = "User profile picture added succesfull!";
                response.Value = ProfilePic;
                return response;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "Error updating the user profile picture.";
                response.Value = ProfilePic;
                return response;
            }
        }
        public Response<UserProfilePic> updateProfilePic(UserProfilePic ProfilePic)
        {
            Response<UserProfilePic> response = new Response<UserProfilePic>();
            try
            {
                _context.Update(ProfilePic);
                _context.SaveChanges();

                response.Success = true;
                response.Message = "User profile picture updated succesfull!";
                response.Value = ProfilePic;
                return response;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "Error updating the user profile picture.";
                response.Value = ProfilePic;
                return response;
            }
        }
    }
}
