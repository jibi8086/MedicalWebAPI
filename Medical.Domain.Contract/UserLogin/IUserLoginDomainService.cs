using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain.Contract.UserLogin
{
    public interface IUserLoginDomainService
    {
        Task<UserLoginDomainDto> AuthenticateUser(UserLoginDomainDto login);
        Task<bool> CreateEmployee(EmployeeDomainDto employee);
        Task<bool> UpdateEmployee(EmployeeDomainDto employee);
    }
}
