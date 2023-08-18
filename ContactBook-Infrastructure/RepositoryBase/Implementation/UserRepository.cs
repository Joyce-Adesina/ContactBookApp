using ContactBook_Domain.Model.Models;
using ContactBook_Infrastructure.Persistence;
using ContactBook_Infrastructure.RepositoryBase.Abstraction;
using ContactBook_Shared.Request_Parameter.ModelParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_Infrastructure.RepositoryBase.Implementation
{
    internal sealed class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DbSet<User> users;

        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            users = appDbContext.Set<User>();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await users.ToListAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await users.Where(u => u.Email.Contains(email, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserById(string id)
        {
            return await users.FindAsync(id);
        }
    }
}
