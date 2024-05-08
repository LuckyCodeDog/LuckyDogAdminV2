using LuckyDog.Admin.Common.ConfigOptions;
using LuckyDog.Admin.Common.Global;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Common.Webapp
{
    public class HttpUser : IHttpUser
    {
        private readonly HttpContext? _httpContext;

        public HttpUser(IHttpContextAccessor httpContextAccessor) 
        {
            _httpContext = httpContextAccessor?.HttpContext;
        }
        public long Id
        {
            get
            {
                if(IsAuthenticated)
                {
                   var claim =   _httpContext?.User.Claims.FirstOrDefault(c => c.Type == "sid");
                   return  Convert.ToInt64(claim?.Value);
                }

                return default(long);
            }
        }
        public string Account
        {
            get {

                if (IsAuthenticated) {
                    return _httpContext?.User?.Claims?.FirstOrDefault(c => c.Type == AuthConstants.JwtClaimTypes.Jti)?.Value ?? string.Empty;
                }
                return string.Empty;
            } 
        }

        public string JwtToken
        {
            get
            {
                if (IsAuthenticated)
                {
                    return _httpContext?.Request?.Headers["Authorization"].ToString()?? string.Empty;
                }
                return string.Empty;
            }
        }

        public bool IsAuthenticated => _httpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}
