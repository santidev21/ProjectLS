using BackEndLS.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndLS.IServices
{
    public interface IUserServices
    {
        string CreateUser(Users users);

        //Methods for the register
        List<PetType> GetPetTypes();
        List<Race> GetRaces(int PetTypeId);

        bool ValidateUser(string username);

        bool ValidateEmail(string email);
    }
}
