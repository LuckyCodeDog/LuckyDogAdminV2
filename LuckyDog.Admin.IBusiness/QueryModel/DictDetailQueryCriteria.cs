using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.QueryModel
{
    /// <summary>
    /// 字典详情查询参数
    /// </summary>
    public class DictDetailQueryCriteria
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 字典名称
        /// </summary>
        public string DictName { get; set; }
    }

}
