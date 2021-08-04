using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain.Contract
{
    public interface IUserService
    {
        Task<bool> AuthenticateUser();
    }
}
