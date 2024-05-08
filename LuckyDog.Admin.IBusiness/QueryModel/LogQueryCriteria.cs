using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.QueryModel
{
    /// <summary>
    /// 日志查询参数
    /// </summary>
    public class LogQueryCriteria : DateRange
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWords { get; set; }
    }
}
