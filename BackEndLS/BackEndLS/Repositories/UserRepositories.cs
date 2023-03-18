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
        public Response<List<PetType>> GetPetTypes() 
        {
            Response<List<PetType>> response = new Response<List<PetType>>();

            List<PetType> petTypes = _context.PetType.ToList();

            response.Success = true;
            response.Value = petTypes;
            response.Message = "Lista de tipos de mascotas obtenida correctamente";


            return response;
        }
        public Response<List<Race>> GetRaces(int PetTypeId)
        {
            Response<List<Race>> response = new Response<List<Race>>();

            List<Race> petTypes = _context.Race.Where(x => x.PetTypeId == PetTypeId).ToList();

            response.Success = true;
            response.Value = petTypes;
            response.Message = "Lista de razas obtenidas correctamente";

            return response;

        }

        public Response<List<Gender>> GetGenders() {

            Response<List<Gender>> response = new Response<List<Gender>>();

            List<Gender> petTypes = _context.Gender.ToList();

            response.Success = true;
            response.Value = petTypes;
            response.Message = "Lista de generos obtenidos correctamente";

            return response;
        }

        public List<UserDetails> GetUserDetails(int UserId) { return _context.UserDetails.Where(x => x.UserId == UserId).ToList(); }
    }
}
