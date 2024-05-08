using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.QueryModel
{
    /// <summary>
    /// 文件记录查询参数
    /// </summary>
    public class FileRecordQueryCriteria : DateRange
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyWords { get; set; }
    }

}
