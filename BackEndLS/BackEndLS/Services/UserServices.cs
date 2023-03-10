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

        public string CreateUser(Users users)
        {
            bool isValidUser = ValidateUser(users.UserName);
            bool isValidEmail = ValidateEmail(users.Email);

            if (isValidUser && isValidEmail)
            {
                users.Password = Encrypt.EncryptPassword(users.Password);
                _userRepositories.CreateUser(users);

                return "Usuario agregado con éxito";
            }
            else if (!isValidUser && !isValidEmail)
            {
                return "El usuario y correo ingresados ya están en uso";
            }
            else if (!isValidEmail)
            {
                return "El correo ingresado ya está en uso";
            }
            else if (!isValidUser)
            {
                return "El usuario ingresado ya está en uso";
            }
     
            else
            {
                return "";
            }


            

        }
        public bool ValidateUser(string username)
        {
            return  _userRepositories.ValidateUser(username);
        }

        public bool ValidateEmail(string email)
        {
            return _userRepositories.ValidateEmail(email);
        }
    }
}
