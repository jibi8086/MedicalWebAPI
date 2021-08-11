using AutoMapper;
using Medical.Domain.Contract;
using Medical.Domain.Contract.UserLogin;
using MedicalWebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalWebAPI.Areas.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region PRIVATE
        private readonly IUserLoginDomainService _userLoginDomainService;
        private readonly IMapper _mapper;
        #endregion

        #region CONSTRUCTOR
        public UserController(IUserLoginDomainService userLoginDomainService, IMapper mapper)
        {
            _userLoginDomainService = userLoginDomainService;
            _mapper = mapper;
        }
        #endregion


        [HttpPost]
        public async Task<UserLoginViewModel> AuthenticateUser(UserLoginViewModel login) {

            try
            {
                var loginDetails = _mapper.Map<UserLoginDomainDto>(login);
                var result = await _userLoginDomainService.AuthenticateUser(loginDetails);
                return _mapper.Map<UserLoginViewModel>(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
