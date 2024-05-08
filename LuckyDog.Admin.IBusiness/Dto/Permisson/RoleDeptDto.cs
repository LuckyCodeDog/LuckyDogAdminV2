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
    /// 角色部门Dto
    /// </summary>
    [AutoMapping(typeof(Department), typeof(RoleDeptDto))]
    public class RoleDeptDto
    {
        /// <summary>
        /// ID
        /// </summary>
        [RegularExpression(@"^\+?[1-9]\d*$")]
        public long Id { get; set; }
    }

}
