using BackEndLS.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndLS.IRepositories
{
    public interface IUserRepositories
    {
        Response<Users> CreateUser(Users users);
        bool ValidateUser(string username);

        bool ValidateEmail(string email);
        // Methods for the register
        Response<List<PetType>> GetPetTypes();
        Response<List<Race>> GetRaces(int PetTypeId);
        Response<List<Gender>> GetGenders();
        Response<List<UserDetails>> GetUserDetails(int UserId);
        Response<UserDetails> SetUserDetail(UserDetails Detail);
        Response<UserProfilePic> GetUserProfilePic(int UserId);
        Response<UserProfilePic> SetUserProfilePic(UserProfilePic ProfilePic);
        Response<UserProfilePic> updateProfilePic(UserProfilePic ProfilePic);
    }
}
