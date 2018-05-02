namespace electronic_journal.DAL.Migrations
{
    using electronic_journal.DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<electronic_journal.DAL.EF.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(electronic_journal.DAL.EF.ApplicationContext context)
        {
            Role studentRole = GetRole("Student");
            Role teacherRole = GetRole("Teacher");
            Role adminRole = GetRole("Admin");

            studentRole = context.Roles.Add(studentRole);
            context.SaveChanges();

            teacherRole = context.Roles.Add(teacherRole);
            context.SaveChanges();

            adminRole = context.Roles.Add(adminRole);
            context.SaveChanges();

            User student = GetUser("student", "123456");
            User teacher = GetUser("teacher", "123456");
            User admin = GetUser("admin", "123456");

            student = context.Users.Add(student);
            context.SaveChanges();

            teacher = context.Users.Add(teacher);
            context.SaveChanges();

            admin = context.Users.Add(admin);
            context.SaveChanges();

            context.UserRoles.Add(GetUserRole(student.Id, studentRole.RoleId));
            context.SaveChanges();

            context.UserRoles.Add(GetUserRole(teacher.Id, teacherRole.RoleId));
            context.SaveChanges();

            context.UserRoles.Add(GetUserRole(admin.Id, adminRole.RoleId));
            context.SaveChanges();
        }

        private User GetUser(string username, string password)
        {
            return new User()
            {
                Id = Guid.NewGuid(),
                Username = username,
                PasswordHash = GetPasswordHash(password)
            };
        }

        private string GetPasswordHash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.SHA512.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        private Role GetRole(string roleName)
        {
            return new Role
            {
                RoleId = Guid.NewGuid(),
                RoleName = roleName
            };
        }

        private UserRole GetUserRole(Guid userId, Guid roleId)
        {
            return new UserRole
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                RoleId = roleId
            };
        }
    }
}
