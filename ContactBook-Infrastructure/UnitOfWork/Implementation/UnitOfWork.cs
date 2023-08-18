using ContactBook_Infrastructure.Persistence;
using ContactBook_Infrastructure.RepositoryBase.Abstraction;
using ContactBook_Infrastructure.UnitOfWork.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_Infrastructure.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IContactRepository _contactRepository;
        private readonly IUserRepository _userRepository;
                   
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IContactRepository ContactRepository 
        { 
            get
            {
                return _contactRepository; 
            } 
        }
        public IUserRepository UserRepository
        {
            get 
            {
            return _userRepository; 
            }
        }
        public async Task SaveAsync() => _context.SaveChangesAsync();
        
    }
}
