﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.QueryModel
{
    /// <summary>
    /// 队列邮件查询参数
    /// </summary>
    public class QueuedEmailQueryCriteria : DateRange
    {
        /// <summary>
        /// 队列ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 最大执行次数
        /// </summary>
        public int MaxTries { get; set; }

        /// <summary>
        /// 发送方
        /// </summary>
        public string Form { get; set; }

        /// <summary>
        /// 接收方
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// 是否已发送
        /// </summary>

        public bool? IsSend { get; set; }
    }

}
