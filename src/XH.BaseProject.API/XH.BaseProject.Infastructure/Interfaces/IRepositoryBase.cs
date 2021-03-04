using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.BaseProject.Infastructure.Interfaces
{
   public interface IRepositoryBase<T> where T: class
    {
        IQueryable<T> GetAll(string includes="");
        Task<T> GetbyId(Guid Id);

        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
