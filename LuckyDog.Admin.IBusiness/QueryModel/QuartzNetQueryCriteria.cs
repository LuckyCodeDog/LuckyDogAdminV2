using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.QueryModel
{
    /// <summary>
    /// 任务调度查询参数
    /// </summary>
    public class QuartzNetQueryCriteria : DateRange
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName { get; set; }
    }
}
