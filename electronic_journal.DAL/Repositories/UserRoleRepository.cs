using System;
using electronic_journal.DAL.EF;
using electronic_journal.DAL.Interfaces;
using electronic_journal.DAL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace electronic_journal.DAL.Repositories
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(ApplicationContext context) : base(context)
        {
        }

        public bool IsInRole(Guid userId, Guid roleId)
        {
            UserRole userRole = _context.UserRoles.FirstOrDefault(ur => ur.UserId == userId && ur.RoleId == roleId);
            if (userRole == null)
            {
                return false;
            }
            return true;
        }

        public async Task<UserRole> AddToRole(Guid userId, Guid roleId)
        {
            UserRole userRole = _context.UserRoles.FirstOrDefault(ur => ur.UserId == userId && ur.RoleId == roleId);
            if (userRole == null)
            {
                userRole = GetEntity(userId, roleId);
                userRole = await Create(userRole);
            }
            return userRole;
        }

        public async Task<UserRole> RemoveFromRole(Guid userId, Guid roleId)
        {
            UserRole userRole = _context.UserRoles.FirstOrDefault(ur => ur.UserId == userId && ur.RoleId == roleId);
            if (userRole != null)
            {
                _context.UserRoles.Remove(userRole);
                await _context.SaveChangesAsync();
            }
            return userRole;
        }

        private UserRole GetEntity(Guid userId, Guid roleId)
        {
            return new UserRole
            {
                UserId = userId,
                RoleId = roleId
            };
        }
    }
}
