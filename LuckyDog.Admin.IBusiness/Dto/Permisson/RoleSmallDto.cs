using LuckyDog.Admin.Common.AttributeExt;
using LuckyDog.Admin.Entity.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.Dto.Permisson
{
    /// <summary>
    /// 角色Dto
    /// </summary>
    [AutoMapping(typeof(Role), typeof(RoleSmallDto))]
    public class RoleSmallDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 权限标识符
        /// </summary>
        public string? Permission { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 数据权限
        /// </summary>
        public string? DataScope { get; set; }
    }
}
