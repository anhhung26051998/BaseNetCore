using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XH.BaseProject.API.SeedWork;
using XH.BaseProject.Common.FilterList;
using XH.BaseProject.Common.Heplers;
using XH.BaseProject.Domain.Users;
using XH.BaseProject.Domain.Users.Dto;
using XH.BaseProject.Infastructure.Interfaces;

namespace XH.BaseProject.API.v1_0.Controller
{
    [Route("v{version:apiVersion=1.0}/users")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepo;
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUserRepository userRepo,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepo = userRepo;
        }
        [HttpGet]
        [ProducesResponseType(typeof(FilterResult<UserDto>), (int)HttpStatusCode.OK)]
        public IActionResult Get([ModelBinder] FilterRequest dataRequest)
        {
            return Ok(_userRepo.GetDataGrid(dataRequest));
        }
        [HttpPost]
        public async void Create([FromBody] User user)
        {
           await _userRepo.InsertAsync(user);
          await _unitOfWork.CommitAsync();
        } 
        [HttpPut]
        public async Task<User> Update([FromBody] User user)
        {
            var c = _userRepo.GetAll().FirstOrDefault();
            MapHelper.Mapper(user,ref c);
          var data= await _userRepo.UpdateAsync(c);
          await _unitOfWork.CommitAsync();
            return data;
        } 

        [HttpDelete]

        public async Task Delete(Guid Id)
        {
            _userRepo.Delete(Id);
            _unitOfWork.CommitAsync();
        }
    }
}
