using LuckyDog.Admin.Common.AttributeExt;
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
    /// <summary>
    /// 部门Dto
    /// </summary>
    [AutoMapping(typeof(Department), typeof(DepartmentDto))]
    public class DepartmentDto : BaseEntityDto<long>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父级Id
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<DepartmentDto> Children { get; set; }

        /// <summary>
        /// 子节点个数
        /// </summary>
        public int SubCount { get; set; }

        /// <summary>
        /// 是否有子节点
        /// </summary>
        public bool HasChildren => SubCount > 0;

        /// <summary>
        /// 页
        /// </summary>
        public bool Leaf => SubCount == 0;

        /// <summary>
        /// 标签
        /// </summary>
        public string Label
        {
            get { return Name; }
        }
    }
}
