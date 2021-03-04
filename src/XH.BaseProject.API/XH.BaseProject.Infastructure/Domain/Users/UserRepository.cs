using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.BaseProject.Domain.Users;
using XH.BaseProject.Infastructure.Database;
using XH.BaseProject.Infastructure.Interfaces;
using XH.BaseProject.Infastructure.Repository;

namespace XH.BaseProject.Infastructure.Domain.Users
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        public UserRepository(BaseContext context) : base(context)
        {

        }
        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAll(string includes = "")
        {
            return base.GetAll();
        }

        public Task<User> GetbyId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> Test()
        {
            return null;
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
