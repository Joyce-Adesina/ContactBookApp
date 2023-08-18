using ContactBook_Infrastructure.RepositoryBase.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_Infrastructure.UnitOfWork.Abstraction
{
    public interface IUnitOfWork
    {
        IContactRepository ContactRepository { get; }
        IUserRepository UserRepository { get; }
        Task SaveAsync();
    }
}
