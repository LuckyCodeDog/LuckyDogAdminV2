using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Entity.Permission
{
    /// <summary>
    /// 角色Apis关联
    /// </summary>
    [SugarTable("sys_role_apis")]
    public class RoleApis
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long RoleId { get; set; }

        /// <summary>
        /// api ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long ApisId { get; set; }
    }
}
