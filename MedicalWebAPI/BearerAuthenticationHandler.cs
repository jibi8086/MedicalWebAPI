using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HRMS.Auth.Domain.Contracts.BusinessDomainModels.Users;
using HRMS.Auth.Domain.Contracts.Services;
using HRMS.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HRMS.Auth.API.Security
{
    public class BearerAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserService _userService;

        public BearerAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserService userService)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            UserDomainModel user = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var _token = authHeader.Parameter;
                if (authHeader != null)
                {
                    var credentialBytes = Convert.FromBase64String(_token);
                    var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' });
                    var militaryId = credentials[1];
                    long ticks = long.Parse(credentials[3]);
                    var timeStamp = new DateTime(ticks);
                    string name = credentials[4];
                    int userId = Convert.ToInt32(credentials[5]);

                    user = await _userService.GetUsersByMilitaryId(militaryId);
                    string computedToken = Cryptor.GenerateToken(user.MilitaryId, user.Hash, "", ticks, name, user.UserId);
                    bool IsAuthenticated = computedToken.Equals(_token, StringComparison.Ordinal);
                    if (!IsAuthenticated)
                    {
                        user.IsAuthenticated = false;

                    }
                    user.IsAuthenticated = true;

                }
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (user == null)
                return AuthenticateResult.Fail("Invalid Token");

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.MilitaryId.ToString()),
                new Claim(ClaimTypes.Name, user.UserId.ToString()),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}














