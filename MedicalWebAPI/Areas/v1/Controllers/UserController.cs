using AutoMapper;
using Medical.Domain.Contract.UserLogin;
using MedicalWebAPI.ViewModels;
using MedicalWebAPI.ViewModels.Generic;
using MedicalWebAPI.ViewModels.ResponseMessage;
using Microsoft.AspNetCore.Mvc;
using System;
using NLog;
using NLog.Fluent;
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
        private readonly ILogger _logger;
        #endregion

        #region CONSTRUCTOR
        public UserController(IUserLoginDomainService userLoginDomainService, IMapper mapper, ILogger logger)
        {
            _userLoginDomainService = userLoginDomainService;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region PUBLIC
        [HttpPost]
        [Route("AuthenticateUser")]
        public async Task<IActionResult> AuthenticateUser(UserLoginViewModel login)
        {

            try
            {
                var loginDetails = _mapper.Map<UserLoginDomainDto>(login);
                var result = await _userLoginDomainService.AuthenticateUser(loginDetails);
                return Ok(new ResponseVM<UserLoginViewModel>(true, ResponseMessages.DATA_ACCESS_SUCCESS, _mapper.Map<UserLoginViewModel>(result)));
            }
            catch (Exception ex)
            {
                _logger.Error()
                    .Exception(ex)
                    .Message($"Login Failed UserID={login.UserName}")
                    .LoggerName("AuthenticateUser")
                    .Property(nameof(login.UserName), login.UserName)
                    .Write();
                return Ok(new ResponseVM<bool>(false, ex.Message));
            }
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(EmployeeViewModel employee)
        {

            try
            {
                var employeeDetails = _mapper.Map<EmployeeDomainDto>(employee);
                var result = await _userLoginDomainService.CreateEmployee(employeeDetails);
                return Ok(new ResponseVM<UserLoginViewModel>(true, ResponseMessages.DATA_ACCESS_SUCCESS, _mapper.Map<UserLoginViewModel>(result)));
            }
            catch (Exception ex)
            {
                _logger.Error()
                    .Exception(ex)
                    .Message($"Login Failed UserID={employee.UserName}")
                    .LoggerName("AuthenticateUser")
                    .Property(nameof(employee.UserName), employee.UserName)
                    .Write();
                return Ok(new ResponseVM<bool>(false, ex.Message));
            }   
        }
        #endregion

    }
}
