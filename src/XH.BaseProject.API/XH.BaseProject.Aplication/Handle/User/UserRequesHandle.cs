using Buca.Common.FilterList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XH.BaseProject.Common.Extentions;
using XH.BaseProject.Common.FilterList;
using XH.BaseProject.Domain.Users;
using XH.BaseProject.Domain.Users.Dto;
using XH.BaseProject.Infastructure.Database;
using XH.BaseProject.Infastructure.Interfaces;
using XH.BaseProject.Infastructure.Repository;

namespace XH.BaseProject.Aplication.Handle.User
{
  public  class UserRequesHandle : RepositoryBase<Domain.Users.User>, IUserRepository
    {
        public IUnitOfWork _unitOfWork;
        public BaseContext _context;
        public UserRequesHandle (IUnitOfWork unitOfWork, BaseContext context) : base(context) 
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }


        public FilterResult<UserDto> GetDataGrid(FilterRequest rq)
        {
            rq.Keyword = rq.Keyword?.ToLower();
            var list = base.GetAll().Where(rq.Filters).OrderBy(rq.Orders).WhereIf(!string.IsNullOrEmpty(rq.Keyword),x=>x.UserName.ToLower().Contains(rq.Keyword));
            return FilterResult.Pagination<Domain.Users.User, UserDto>(list, rq);
        }
    }
}
