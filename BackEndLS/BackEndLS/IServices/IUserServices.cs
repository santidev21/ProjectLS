using BackEndLS.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndLS.IServices
{
    public interface IUserServices
    {
        string CreateUser(Users users);

        //Methods for the register
        Response<List<PetType>> GetPetTypes();
        Response<List<Race>> GetRaces(int PetTypeId);
        Response<List<Gender>> GetGenders();
        List<UserDetails> GetUserDetails(int userId);
        bool ValidateUser(string username);

        bool ValidateEmail(string email);
    }
}
