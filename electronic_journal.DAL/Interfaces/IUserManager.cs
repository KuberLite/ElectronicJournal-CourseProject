using electronic_journal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electronic_journal.DAL.Interfaces
{
    public interface IUserManager
    {
        User CurrentUser { get; }

        bool CheckForUniqueUsername(string username);

        User SignIn(string userName, string password);

        User SignOut();

        Task<User> Register(User user, string password);

        bool IsInRole(Guid userId, string roleName);

        Task<UserRole> AddToRole(Guid userId, string roleName);

        Task<UserRole> RemoveFromRole(Guid userId, string roleName);
    }
}
