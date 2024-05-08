using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Common.Webapp
{
    public interface IHttpUser
    {
        /// <summary>
        /// 当前登录用户ID
        /// </summary>
        long Id { get; }

        /// <summary>
        /// 当前登录用户名称
        /// </summary>
        string Account { get; }


        /// <summary>
        /// 请求携带的Token
        /// </summary>
        /// <returns></returns>
        string JwtToken { get; }

        /// <summary>
        /// 是否已认证
        /// </summary>
        /// <returns></returns>
        bool IsAuthenticated { get; }
    }
}
