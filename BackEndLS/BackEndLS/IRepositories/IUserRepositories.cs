using BackEndLS.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndLS.IRepositories
{
    public interface IUserRepositories
    {
        Users CreateUser(Users users);
    }
}
