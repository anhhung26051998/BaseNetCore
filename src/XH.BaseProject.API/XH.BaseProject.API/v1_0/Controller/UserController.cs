using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XH.BaseProject.API.SeedWork;
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
        //[ProducesResponseType(typeof(FilterResult<UserDto>), (int)HttpStatusCode.OK)]
        public IActionResult Index()
        {
            return Ok(_userRepo.GetAll());
        }
    }
}
