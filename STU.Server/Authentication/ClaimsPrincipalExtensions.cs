using STU.Server.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace STU.Server.Authentication
{
    public static class ClaimsPrincipalExtensions
    {
        public static int? GetAccountId(this ClaimsPrincipal user)
        {
            if (user == null || user.Claims == null) return null;

            string userId = user.FindFirstValue(AuthConstants.USER_ID_CLAIM_TYPE);

            if (int.TryParse(userId, out int id)) return id;
            else return null;
        }
    }
}
