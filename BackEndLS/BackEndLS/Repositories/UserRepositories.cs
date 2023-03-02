using BackEndLS.IRepositories;
using BackEndLS.Models;
using BackEndLS.Persistence.Context;
using Microsoft.AspNetCore.Mvc;


namespace BackEndLS.Repositories
{
    public class UserRepositories: IUserRepositories
    {
        private readonly LSContext _context;
        public UserRepositories(LSContext context)
        {
            _context = context;
        }

        public Users CreateUser(Users users)
        {
            _context.Add(users);
            _context.SaveChanges();

            return users;
        }
    }
}
