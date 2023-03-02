using BackEndLS.IRepositories;
using BackEndLS.IServices;
using BackEndLS.Models;
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

        public Users CreateUser(Users users)
        {
            _userRepositories.CreateUser(users);
            return users;
        }
    }
}
