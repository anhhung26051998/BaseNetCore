using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XH.BaseProject.Domain.SeedWork;

namespace XH.BaseProject.Infastructure.Interfaces
{
  public  interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
        void Register<TEntity>(IRepositoryBase<TEntity> repository) where TEntity : class;

        IRepositoryBase<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
