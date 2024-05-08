using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Common.Global
{
    /// <summary>
    /// 运行模式
    /// </summary>
    public enum RunMode
    {
        /// <summary>
        /// 本地开发
        /// </summary>
        Dev,

        /// <summary>
        /// 演示环境
        /// </summary>
        Demo,

        /// <summary>
        /// 发布
        /// </summary>
        Publish
    }
}
