using BackEndLS.IRepositories;
using BackEndLS.IServices;
using BackEndLS.Models;
using BackEndLS.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackEndLS.Services
{
    public class UserServices: IUserServices
    {
        private readonly IUserRepositories _userRepositories;
        public UserServices(IUserRepositories userRepositories)
        {
            _userRepositories = userRepositories;
        }

        public Response<Users> CreateUser(Users users)
        {
            try
            {
                bool isValidUser = ValidateUser(users.UserName);
                bool isValidEmail = ValidateEmail(users.Email);

                Response<Users> response = new Response<Users>();

                if (isValidUser && isValidEmail)
                {
                    users.Password = Encrypt.EncryptPassword(users.Password);
                    response = _userRepositories.CreateUser(users);
                }
                else if (!isValidUser && !isValidEmail)
                {
                    response.Success = false;
                    response.Value = null;
                    response.Message = "The username and email entered are already in use";
                }
                else if (!isValidEmail)
                {
                    response.Success = false;
                    response.Value = null;
                    response.Message = "The email entered is already in use";
                }
                else if (!isValidUser)
                {
                    response.Success = false;
                    response.Value = null;
                    response.Message = "The entered user is already in use";
                }
                else
                {
                    response.Success = false;
                    response.Value = null;
                    response.Message = "Other validation error, please contact support.";
                }
                return response;

            }
            catch (Exception)
            {
                Response<Users> response = new Response<Users>(false, "S - There was an error trying to create the user, please contact support.", null);
                return response;
            }


        }

        public string CreateUserDetail()
        {
            return "";
        }

        public bool ValidateUser(string username)
        {
            return  _userRepositories.ValidateUser(username);
        }

        public bool ValidateEmail(string email)
        {
            return _userRepositories.ValidateEmail(email);
        }

        // Methods for the register x
        public Response<List<PetType>> GetPetTypes() { return _userRepositories.GetPetTypes(); }
        public Response<List<Race>> GetRaces(int PetTypeId) { return _userRepositories.GetRaces(PetTypeId); }
        public Response<List<Gender>> GetGenders() { return _userRepositories.GetGenders(); }
        public Response<List<UserDetails>> GetUserDetails(int userId) { return _userRepositories.GetUserDetails(userId); }
        public Response<UserDetails> SetUserDetail(UserDetails Detail) { return _userRepositories.SetUserDetail(Detail);}
        public Response<UserProfilePic> GetUserProfilePic(int UserId) { return _userRepositories.GetUserProfilePic(UserId); }
        public Response<UserProfilePic> SetUserProfilePic(UserProfilePic ProfilePic) 
        {
            try
            {
                Response<UserProfilePic> response = new Response<UserProfilePic>();
                Response<UserProfilePic> userHasPic = _userRepositories.GetUserProfilePic(ProfilePic.UserId);
                if (userHasPic.Value != null) 
                {
                    userHasPic.Value.Pic = ProfilePic.Pic;
                    response = _userRepositories.updateProfilePic(userHasPic.Value);
                } else
                {
                    response = _userRepositories.SetUserProfilePic(ProfilePic);
                }
                return response;
            }
            catch (Exception)
            {
                Response<UserProfilePic> response = new Response<UserProfilePic>(false, "S - There was an error trying to set the user profile pic, please contact support.", null);
                return response;
            }
        }
        public Response<UserProfilePic> updateProfilePic(UserProfilePic ProfilePic) 
        {
            try
            {
                Response<UserProfilePic> userHasPic = _userRepositories.GetUserProfilePic(ProfilePic.UserId);
                if (userHasPic.Value != null)
                {
                    Response<UserProfilePic> response = new Response<UserProfilePic>();
                    userHasPic.Value.Pic = ProfilePic.Pic;
                    response = _userRepositories.updateProfilePic(userHasPic.Value);
                    return response;
                }
                else
                {
                    Response<UserProfilePic> response = new Response<UserProfilePic>(false, "User does not exist", null);
                    return response;
                }
            }
            catch (Exception)
            {
                Response<UserProfilePic> response = new Response<UserProfilePic>(false, "S - There was an error trying to update the user profile pic, please contact support.", null);
                return response;
            }   

        }
    }
}
