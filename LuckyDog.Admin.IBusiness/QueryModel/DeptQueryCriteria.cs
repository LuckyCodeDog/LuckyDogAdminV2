using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.QueryModel
{

    /// <summary>
    /// 部门查询参数
    /// </summary>
    public class DeptQueryCriteria : DateRange
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public long? ParentId { get; set; }
    }

}
