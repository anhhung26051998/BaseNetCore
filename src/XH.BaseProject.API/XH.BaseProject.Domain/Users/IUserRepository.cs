using System;
using System.Collections.Generic;
using System.Text;
using XH.BaseProject.Common.FilterList;
using XH.BaseProject.Domain.SeedWork;
using XH.BaseProject.Domain.Users.Dto;

namespace XH.BaseProject.Domain.Users
{
   public interface IUserRepository : IRepositoryBase<User>
    {
        FilterResult<UserDto> GetDataGrid(FilterRequest rq);
    }
}
