using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.QueryModel
{
    /// <summary>
    /// 密钥查询参数
    /// </summary>
    public class AppsecretQueryCriteria : DateRange
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWords { get; set; }
    }

}
