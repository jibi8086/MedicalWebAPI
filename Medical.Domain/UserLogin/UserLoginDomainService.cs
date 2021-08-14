using AutoMapper;
using Medical.Data.Contract.UserLogin;
using Medical.Domain.Contract.UserLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain.UserLogin
{
    public class UserLoginDomainService: IUserLoginDomainService
    {
        #region PRIVATE
        private readonly IUserLoginDataAccess _userLoginDataAccess;
        private readonly IMapper _mapper;
        #endregion

        #region CONSTRUCTOR
        public UserLoginDomainService(IUserLoginDataAccess userLoginDataAccess, IMapper mapper)
        {
            _userLoginDataAccess = userLoginDataAccess;
            _mapper = mapper;
        }
        #endregion
        public async Task<UserLoginDomainDto> AuthenticateUser(UserLoginDomainDto login) {

            var loginDetails = _mapper.Map<UserLoginData>(login);
            var result= await _userLoginDataAccess.AuthenticateUser(loginDetails);
            return _mapper.Map<UserLoginDomainDto>(result);
        }   
        public async Task<bool> CreateEmployee(EmployeeDomainDto employee) {

            var employeeDetails = _mapper.Map<EmployeeData>(employee);
            var result= await _userLoginDataAccess.CreateEmployee(employeeDetails);
            return result;
        }   

    }
}
