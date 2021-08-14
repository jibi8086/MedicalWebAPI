using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Data.Contract.UserLogin
{
    public interface IUserLoginDataAccess
    {
        Task<UserLoginData> AuthenticateUser(UserLoginData login);
        Task<bool> CreateEmployee(EmployeeData employee);
    }
}
