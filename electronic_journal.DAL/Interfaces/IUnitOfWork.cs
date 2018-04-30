using electronic_journal.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electronic_journal.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ApplicationContext Context { get; }

        IUserManager UserManager { get; }
    }
}
