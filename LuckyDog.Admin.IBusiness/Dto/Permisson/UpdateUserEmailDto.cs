﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.Dto.Permisson
{
    /// <summary>
    /// 用户邮箱Dto
    /// </summary>
    public class UpdateUserEmailDto
    {
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string? Password { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required]
        public string? Code { get; set; }
    }
}
