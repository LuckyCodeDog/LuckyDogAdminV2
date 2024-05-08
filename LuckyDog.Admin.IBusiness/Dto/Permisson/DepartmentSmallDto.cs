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
    /// 部门Dto
    /// </summary>
    [AutoMapping(typeof(Department), typeof(DepartmentSmallDto))]
    public class DepartmentSmallDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }

}
