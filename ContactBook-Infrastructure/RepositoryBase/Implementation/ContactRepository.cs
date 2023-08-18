using ContactBook_Domain.Model.Models;
using ContactBook_Infrastructure.Persistence;
using ContactBook_Infrastructure.RepositoryBase.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ContactBook_Infrastructure.RepositoryBase.Implementation
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
            private readonly DbSet<Contact> _contacts;
            public ContactRepository(AppDbContext appDbContext) : base(appDbContext)
            {
                _contacts = appDbContext.Set<Contact>();
            }

            public async Task<IEnumerable<Contact>> GetAllContacts()
            {
                return await _contacts.ToListAsync();
            }

            public async Task<Contact> GetContactByEmail(string email)
            {
                return await _contacts.Where(c => c.Email.Contains(email, StringComparison.InvariantCultureIgnoreCase))
                    .FirstOrDefaultAsync();
            }

            public async Task<Contact> GetContactById(int id)
            {
                return await _contacts.FindAsync(id);
            }
        }
    }
