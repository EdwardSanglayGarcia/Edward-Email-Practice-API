using Microsoft.EntityFrameworkCore;
using EdwardAPI.Model;

namespace EdwardAPI.Data
{
    public class EdwardDBContext : DbContext
    {
        public EdwardDBContext(DbContextOptions<EdwardDBContext> options) : base(options)
        {

        }

        public DbSet<Mail> Mails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
