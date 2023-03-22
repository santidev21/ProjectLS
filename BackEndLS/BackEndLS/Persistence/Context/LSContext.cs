using BackEndLS.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndLS.Persistence.Context
{
    public class LSContext : DbContext
    {
        public DbSet<Users> User { get; set; }
        public DbSet<PetType> PetType { get; set; }
        public DbSet<Race> Race { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<UserProfilePic> UserProfilePic { get; set; }
        public LSContext(DbContextOptions<LSContext> options) : base(options) { }

    }
}
