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
    /// 用户角色Dto
    /// </summary>
    [AutoMapping(typeof(Role), typeof(UserRoleDto))]
    public class UserRoleDto
    {
        /// <summary>
        /// ID
        /// </summary>
        [RegularExpression(@"^\+?[1-9]\d*$")]
        public long Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
