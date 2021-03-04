using System;
using System.Collections.Generic;
using System.Text;
using XH.BaseProject.Domain.SeedWork;

namespace XH.BaseProject.Domain.Users
{
   public interface IUserRepository : IRepositoryBase<User>
    {
         List<User> Test();
    }
}
