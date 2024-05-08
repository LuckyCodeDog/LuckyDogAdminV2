using AutoMapper;
using LuckyDog.Admin.Common.ConfigOptions;
using LuckyDog.Admin.Common.Extention;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Common.Webapp
{
    public class ApeContext
    {

        private Configs _configs;
        public Configs Configs { get { return _configs; } }


        private HttpContext? _httpContext;
        public HttpContext? HttpContext { get { return _httpContext; } }


        private IMapper _mapper;
        public IMapper Mapper { get { return _mapper; } }


        private IHttpUser _httpUser;

        public IHttpUser HttpUser{get { return _httpUser; }}




        public LoginUserInfo? LoginUserInfo
        {
            get
            {
                if (!HttpUser.JwtToken.IsNullOrEmpty())
                {
                    return new LoginUserInfo();
                }
                return null;
            }
        }

        /// <summary>
        /// add Cache later
        /// </summary>
        /// <param name="configs"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="httpUser"></param>
        /// <param name="mapper"></param>
        public ApeContext(IOptionsMonitor<Configs> configs, IHttpContextAccessor httpContextAccessor, IHttpUser httpUser, IMapper mapper)
        {
            _configs = configs.CurrentValue??new Configs();
            _httpContext = httpContextAccessor?.HttpContext; 
            _mapper = mapper;
            _httpUser = httpUser;
        }
    }
}
