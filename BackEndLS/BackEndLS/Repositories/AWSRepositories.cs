using BackEndLS.IRepositories;
using BackEndLS.Models;
using BackEndLS.Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndLS.Repositories
{
    public class AWSRepositories: IAWSRepositories
    {
        private readonly LSContext _context;
        public AWSRepositories(LSContext context)
        {
            _context = context;
        }

        public Response<string> SavePhoto(string photo)
        {
            var response = new Response<string>();
            return response;
        }


    }
}
