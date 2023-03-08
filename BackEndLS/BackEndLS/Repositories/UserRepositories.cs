using BackEndLS.IRepositories;
using BackEndLS.Models;
using BackEndLS.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndLS.Repositories
{
    public class UserRepositories: IUserRepositories
    {
        private readonly LSContext _context;
        public UserRepositories(LSContext context)
        {
            _context = context;
        }

        public void CreateUser(Users users)
        {
            _context.Add(users);
            _context.SaveChanges();
        }
        public bool ValidateUser(string username)
        {
            return _context.User.Where(x => x.UserName == username).ToList().Count() > 0 ? false : true;
        }

        public bool ValidateEmail(string email)
        {
            return _context.User.Where(x => x.Email == email).ToList().Count() > 0 ? false : true;
        }
    }
}
