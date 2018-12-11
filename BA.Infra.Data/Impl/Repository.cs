using BA.Core.Interface;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BA.Infra.Data.Impl
{
    public sealed class Repository<T> : IRepository<T> where T : class
    {
        private readonly BADbContext _dbContext;


        public IQueryable<T> Entities => _dbContext.Set<T>();

        public Repository(BADbContext dbContext) {

            _dbContext = dbContext;
            
        }

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbContext.Add(entity);
        }

        public T GetById(int id)
        {
            var dbset = Entities as DbSet<T>;

            return dbset.Find(id);
        }

        public void Remove(int id)
        {
            var entity = GetById(id);

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbContext.Remove(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbContext.Update(entity);
        }
    }
}
