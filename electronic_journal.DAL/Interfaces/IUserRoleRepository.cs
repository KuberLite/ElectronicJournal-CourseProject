using electronic_journal.DAL.Models;
using System;
using System.Threading.Tasks;

namespace electronic_journal.DAL.Interfaces
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        bool IsInRole(Guid userId, Guid roleId);

        Task<UserRole> AddToRole(Guid userId, Guid roleId);

        Task<UserRole> RemoveFromRole(Guid userId, Guid roleId);
    }
}
