using LuckyDog.Admin.Common.AttributeExt;
using LuckyDog.Admin.Entity.Permission;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.Dto.Permisson
{
    /// <summary>
    /// 角色菜单Dto
    /// </summary>
    [AutoMapping(typeof(Apis), typeof(RoleApisDto))]
    public class RoleApisDto
    {
        /// <summary>
        /// ID
        /// </summary>
        [RegularExpression(@"^\+?[1-9]\d*$")]
        public long Id { get; set; }
    }
}
