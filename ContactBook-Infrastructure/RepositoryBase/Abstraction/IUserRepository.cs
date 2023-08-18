using ContactBook_Domain.Model.Models;
using ContactBook_Infrastructure.Persistence;
using ContactBook_Infrastructure.RepositoryBase.Implementation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_Infrastructure.RepositoryBase.Abstraction
{
  
        public interface IUserRepository
        {

            Task<IEnumerable<User>> GetAllUsers();

            Task<User> GetUserByEmail(string email);

        Task<User> GetUserById(string id);
        }
    
}
