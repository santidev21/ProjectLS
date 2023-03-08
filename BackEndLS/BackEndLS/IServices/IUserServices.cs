using BackEndLS.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndLS.IServices
{
    public interface IUserServices
    {
        string CreateUser(Users users);

        bool ValidateUser(string username);

        bool ValidateEmail(string email);
    }
}
