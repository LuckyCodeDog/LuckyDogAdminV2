using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.QueryModel
{

    /// <summary>
    /// 
    /// </summary>
    public class ApisQueryCriteria
    {
        /// <summary>
        /// 组名称
        /// </summary>
        public string? Group { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 请求方法
        /// </summary>
        public string? Method { get; set; }
    }
}
