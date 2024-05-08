using LuckyDog.Admin.Entity.Permission;
using LuckyDog.Admin.IBusiness.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.Dto.Permisson
{
    public class RoleDto : BaseEntityDto<long>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 数据权限
        /// </summary>
        public string? DataScope { get; set; }

        /// <summary>
        /// 权限标识
        /// </summary>
        public string? Permission { get; set; }

        /// <summary>
        /// 菜单列表
        /// </summary>
        [JsonProperty(PropertyName = "menus")]
        public List<MenuDto>? MenuList { get; set; }

        /// <summary>
        /// 部门列表
        /// </summary>
        [JsonProperty(PropertyName = "depts")]
        public List<DepartmentDto>? DepartmentList { get; set; }

        /// <summary>
        /// 菜单列表
        /// </summary>
        [JsonProperty(PropertyName = "apis")]
        public List<Apis>? Apis { get; set; }
    }
}
