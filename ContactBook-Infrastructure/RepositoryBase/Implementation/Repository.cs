using ContactBook_Infrastructure.Persistence;
using ContactBook_Infrastructure.RepositoryBase.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_Infrastructure.RepositoryBase.Implementation
{
    public abstract class Repository<T> : IRepositoryBase<T> where T : class
    {


        private readonly DbSet<T> context;

        public Repository(AppDbContext appDbContext)
        {
            context = appDbContext.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await context.AddAsync(entity);
        }

        public async Task CreateRangeAsync(IEnumerable<T> entities)
        {
            await context.AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            context.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            context.Update(entity);
        }
    }



}



