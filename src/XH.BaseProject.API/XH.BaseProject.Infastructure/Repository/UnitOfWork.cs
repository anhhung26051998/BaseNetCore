using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XH.BaseProject.Domain.SeedWork;
using XH.BaseProject.Infastructure.Database;
using XH.BaseProject.Infastructure.Interfaces;

namespace XH.BaseProject.Infastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly BaseContext _context;
        private Dictionary<string, object> _repositories;
        public UnitOfWork(BaseContext context)
        {
            _context = context;
            _repositories = new Dictionary<string, object>();
        }
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
           return   _context.SaveChangesAsync().GetAwaiter().GetResult();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Register<TEntity>(IRepositoryBase<TEntity> repository) where TEntity : class
        {
            var typeName = repository.GetType().FullName;
            if (!_repositories.ContainsKey(typeName))
            {
                _repositories.Add(typeName, repository);
            }
            else
            {
                _repositories[typeName] = repository;
            }
            repository.SetDbContext(_context);
        }

        public IRepositoryBase<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            string typeName = typeof(IRepositoryBase<TEntity>).FullName;

            if (_repositories.ContainsKey(typeName))
            {
                return (IRepositoryBase<TEntity>)_repositories[typeName];
            }
            throw new Exception($"{typeName} not found");
        }

    }
}
