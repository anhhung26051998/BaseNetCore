
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.BaseProject.Domain.SeedWork;
using XH.BaseProject.Infastructure.Database;
using XH.BaseProject.Infastructure.Interfaces;

namespace XH.BaseProject.Infastructure.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class 
    {

        private BaseContext _context;
        private DbSet<TEntity> _dbSet => _context.Set<TEntity>();

        public RepositoryBase(BaseContext context)
        {
            _context = context;
        }
        public virtual void Delete(Guid Id)
        {
            var entity = _dbSet.Find(Id);
            if(entity!=null)
            _dbSet.Remove(entity);
        }

        public virtual IQueryable<TEntity> GetAll(string includes="")
        {
            IQueryable<TEntity> query = _dbSet;
            foreach (var includeProperty in includes.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public virtual async Task<TEntity> GetbyId(Guid Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public virtual  Task<TEntity> InsertAsync(TEntity entity)
        {
             _dbSet.Add(entity);
            return  Task.FromResult(entity);
        }

        public void SetDbContext(object dbContext)
        {
            _context = dbContext as BaseContext;
        }

        public virtual  Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
            return  Task.FromResult(entity);
        }

    }
}
