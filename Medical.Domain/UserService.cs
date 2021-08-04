using Medical.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain
{
    public class UserService : IUserService
    {
        public async Task<bool> AuthenticateUser()
        {

            return true;
        }
    }
}
