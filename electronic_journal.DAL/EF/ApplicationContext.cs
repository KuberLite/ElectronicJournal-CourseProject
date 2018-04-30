using electronic_journal.DAL.Models;
using System.Data.Entity;

namespace electronic_journal.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }

        public DbSet<Faculty> Facultys { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Profession> Professions { get; set; }

        public DbSet<Pulpit> Pulpits { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Subject> Subjects { get; set; } 

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
    }
}
