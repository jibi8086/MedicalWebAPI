using Medical.Domain.Contract;
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
        private IUserService _userService;
        #endregion
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<bool> AuthenticateUser() {

            return await _userService.AuthenticateUser();
        }
    }
}
