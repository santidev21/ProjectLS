using BackEndLS.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndLS.IServices
{
    public interface IUserServices
    {
        Users CreateUser(Users users);
    }
}
