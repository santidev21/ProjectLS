using BackEndLS.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndLS.IRepositories
{
    public interface IUserRepositories
    {
        void CreateUser(Users users);
        bool ValidateUser(string username);

        bool ValidateEmail(string email);
    }
}
