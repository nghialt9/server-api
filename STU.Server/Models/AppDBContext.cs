using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STU.Server.Models
{
    public class AppDBContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContext;

        public AppDBContext(DbContextOptions<AppDBContext> options, IHttpContextAccessor httpContext) : base(options)
        {
            _httpContext = httpContext;
        }
    }
}
