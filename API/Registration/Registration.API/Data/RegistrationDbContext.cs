using Microsoft.EntityFrameworkCore;
using Registration.API.Models;

namespace Registration.API.Data
{
    public class RegistrationDbContext : DbContext
    {
        public RegistrationDbContext(DbContextOptions options) : base(options)
        {   

        }

        //DbSet

        public DbSet<Registrations> Registration { get; set; }
    }
}
