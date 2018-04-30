using electronic_journal.DAL.EF;
using electronic_journal.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electronic_journal.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private static UnitOfWork unitOfWork;
        private readonly ApplicationContext _context;
        private readonly UserManager _userManager;

        private UnitOfWork()
        {
            _context = new ApplicationContext();
            _userManager = new UserManager(_context);
        }

        public static UnitOfWork GetInstance()
        {
            if (unitOfWork == null)
            {
                unitOfWork = new UnitOfWork();
            }
            return unitOfWork;
        }

        public ApplicationContext Context => _context;

        public IUserManager UserManager => _userManager;
    }
}
