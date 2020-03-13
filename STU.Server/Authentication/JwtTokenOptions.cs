using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace STU.Server.Authentication
{
    public class JwtTokenOptions
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public Double MinExpiration { get; set; }
        public Double StaffMinExpiration { get; set; }
        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(20);
        public TimeSpan ExpirationForStaff { get; set; } = TimeSpan.FromHours(1);
        public SigningCredentials SigningCredentials { get; set; }
    }
}
