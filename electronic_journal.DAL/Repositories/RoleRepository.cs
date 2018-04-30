using electronic_journal.DAL.EF;
using electronic_journal.DAL.Interfaces;
using electronic_journal.DAL.Models;

namespace electronic_journal.DAL.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
