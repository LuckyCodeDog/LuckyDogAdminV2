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
    /// 
    /// </summary>
    [AutoMapping(typeof(Apis), typeof(CreateUpdateApisDto))]
    public class CreateUpdateApisDto : BaseEntityDto<long>
    {
        /// <summary>
        /// 组
        /// </summary>
        [Required]
        public string Group { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        [Required]
        public string Url { get; set; }


        /// <summary>
        /// 描述
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// 请求方法
        /// </summary>
        [Required]
        public string Method { get; set; }
    }
}
