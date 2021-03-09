using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.BaseProject.Common.FilterList;

namespace XH.BaseProject.Domain.SeedWork
{
   public interface IRepositoryBase<T> where T: class
    {
        IQueryable<T> GetAll(string includes="");
        Task<T> GetbyId(Guid Id);

        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        void Delete(Guid Id);
        void SetDbContext(object dbContext);

    }
}
