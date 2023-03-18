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

        // Methods for the register
        public List<PetType> GetPetTypes() 
        {
            return _context.PetType.ToList();
        }
        public List<Race> GetRaces(int PetTypeId)
        {
            return _context.Race.Where(x => x.PetTypeId == PetTypeId).ToList();
        }
        public List<Gender> GetGenders() { return _context.Gender.ToList(); }
        public List<UserDetails> GetUserDetails(int UserId) { return _context.UserDetails.Where(x => x.UserId == UserId).ToList(); }
    }
}
