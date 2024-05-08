﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.QueryModel
{
    /// <summary>
    /// 邮箱模板查询参数
    /// </summary>
    public class EmailMessageTemplateQueryCriteria : DateRange
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool? IsActive { get; set; }
    }
}
