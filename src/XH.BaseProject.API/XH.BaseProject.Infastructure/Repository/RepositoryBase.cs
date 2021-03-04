using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.BaseProject.Infastructure.Database;
using XH.BaseProject.Infastructure.Interfaces;

namespace XH.BaseProject.Infastructure.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private BaseContext _context;
        private DbSet<TEntity> _dbSet;
        public RepositoryBase(BaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<TEntity> GetAll(string includes="")
        {
            IQueryable<TEntity> query = _dbSet;
            foreach (var includeProperty in includes.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query.AsNoTracking();
        }

        public async Task<TEntity> GetbyId(Guid Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public async void Insert(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}
