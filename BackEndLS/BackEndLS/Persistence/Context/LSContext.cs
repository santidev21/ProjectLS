using BackEndLS.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndLS.Persistence.Context
{
    public class LSContext : DbContext
    {
        public DbSet<Users> User { get; set; }
        public LSContext(DbContextOptions<LSContext> options) : base(options) { }

    }
}
