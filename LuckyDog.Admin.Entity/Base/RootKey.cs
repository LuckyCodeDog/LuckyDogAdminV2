using LuckyDog.Admin.Common.SnowflakeIdHelper;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Entity.Base
{
    /// <summary>
    /// 泛型主键
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RootKey<T> where T : IEquatable<T>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public T? Id { get; set; } 
    }
}
