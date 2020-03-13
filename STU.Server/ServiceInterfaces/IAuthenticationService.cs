using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace STU.Server.ServiceInterfaces
{
    public interface IAuthenticationService
    {
        Task<bool> ValidateTokenAsync(ClaimsPrincipal user);
        Task<string> EnableOrDisableSecurityTokenAsync(int accountId, bool isEnable);
        Task LogoutAsync(ClaimsPrincipal user);
        Task<bool> CheckForceLogin365(int accountId);
        Task<bool> ResetMacAddress(int accountID);
        Task<bool> MacAddressCheck(int accountID, int flag);
    }
}
