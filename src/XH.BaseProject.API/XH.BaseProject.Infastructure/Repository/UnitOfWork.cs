using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XH.BaseProject.Infastructure.Database;
using XH.BaseProject.Infastructure.Interfaces;

namespace XH.BaseProject.Infastructure.Repository
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        public readonly BaseContext _context;
        public UnitOfWork(BaseContext context)
        {
            _context = context;
        }
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
           return  await _context.SaveChangesAsync();
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

    }
}
