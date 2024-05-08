using LuckyDog.Admin.Common.AttributeExt;
using LuckyDog.Admin.Entity.Permission;
using LuckyDog.Admin.IBusiness.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.Dto.Permisson
{

    /// <summary>
    /// 角色Dto
    /// </summary>
    [AutoMapping(typeof(Role), typeof(CreateUpdateRoleDto))]
    public class CreateUpdateRoleDto : BaseEntityDto<long>
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 数据权限
        /// </summary>
        public string DataScope { get; set; }

        /// <summary>
        /// 标识
        /// </summary>
        [Required]
        public string Permission { get; set; }

        /// <summary>
        /// 角色部门
        /// </summary>
        public List<RoleDeptDto> Depts { get; set; }

        /// <summary>
        /// 角色菜单
        /// </summary>
        public List<RoleMenuDto> Menus { get; set; }

        /// <summary>
        /// 角色菜单
        /// </summary>
        public List<RoleApisDto> Apis { get; set; }
    }
}
