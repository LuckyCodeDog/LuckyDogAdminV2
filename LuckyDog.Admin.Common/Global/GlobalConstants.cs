﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Common.Global
{
    public static class CacheKey
    {
        /// <summary>
        /// 在线
        /// </summary>
        public const string OnlineKey = "OnlineToken:";

        /// <summary>
        /// 验证码
        /// </summary>
        public const string CaptchaId = "CaptchaId:";

        /// <summary>
        /// 邮箱验证码
        /// </summary>
        public const string EmailCaptchaKey = "EmailCaptcha:";

        /// <summary>
        /// 加载用户信息
        /// </summary>
        public const string UserInfoByName = "user:info:name:";

        public const string UserInfoById = "user:info:id:";

        public const string UserRolesById = "user:roles:id:";

        public const string UserJobsById = "user:jobs:id:";

        public const string UserBuildMenuById = "user:build:menu:id:";

        public const string UserPermissionRoles = "user:permissionRole:id:";
        public const string UserPermissionUrls = "user:permissionUrl:id:";

        public const string LoadMenusByPId = "menu:pid:";

        public const string LoadMenusById = "menu:id:";

        public const string LoadSettingByName = "setting:name:";
    }
}
