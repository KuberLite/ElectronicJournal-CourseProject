using electronic_journal.DAL.Interfaces;
using electronic_journal.DAL.Models;
using electronic_journal.DAL.EF;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electronic_journal.DAL.Repositories
{
    public class UserManager : IUserManager
    {
        private static User _currentUser;
        private readonly ApplicationContext _context;
        private readonly IRoleRepository roleRepository;
        private readonly IUserRoleRepository userRoleRepository;

        public User CurrentUser => _currentUser;

        static UserManager()
        {
            _currentUser = null;
        }

        public UserManager(ApplicationContext context)
        {
            _context = context;
            roleRepository = new RoleRepository(_context);
            userRoleRepository = new UserRoleRepository(_context);
        }

        public bool CheckForUniqueUsername(string username)
        {
            User user = _context.Users.FirstOrDefault(u => u.Username.Equals(username));
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public User SignIn(string userName, string password)
        {
            string passwordHash = GetPasswordHash(password);
            User user = _context.Users.FirstOrDefault(u => u.Username.Equals(userName) && u.PasswordHash.Equals(passwordHash));
            return user;
        }

        public User SignOut()
        {
            _currentUser = null;
            return _currentUser;
        }

        public async Task<User> Register(User user, string password)
        {
            user.PasswordHash = GetPasswordHash(password);
            if (CheckForUniqueUsername(user.Username))
            {
                user = _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            return user;
        }

        public bool IsInRole(Guid userId, string roleName)
        {
            Role role = roleRepository.Query().FirstOrDefault(r => r.RoleName.Equals(roleName));
            if (role == null)
            {
                return false;
            }
            return userRoleRepository.IsInRole(userId, role.RoleId);
        }

        public async Task<UserRole> AddToRole(Guid userId, string roleName)
        {
            Role role = roleRepository.Query().FirstOrDefault(r => r.RoleName.Equals(roleName));
            if (role != null)
            {
                return await userRoleRepository.AddToRole(userId, role.RoleId);
            }
            return null;
        }

        public async Task<UserRole> RemoveFromRole(Guid userId, string roleName)
        {
            Role role = roleRepository.Query().FirstOrDefault(r => r.RoleName.Equals(roleName));
            if (role != null)
            {
                return await userRoleRepository.RemoveFromRole(userId, role.RoleId);
            }
            return null;
        }

        private string GetPasswordHash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.SHA512.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
