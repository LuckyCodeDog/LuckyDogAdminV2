using LuckyDog.Admin.Common.AttributeExt;
using LuckyDog.Admin.Entity.Permission;
using LuckyDog.Admin.IBusiness.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.Dto.Permisson
{
    /// <summary>
    /// 用户岗位Dto
    /// </summary>
    [AutoMapping(typeof(UserJob), typeof(CreateUpdateUserJobDto))]
    public class CreateUpdateUserJobDto : BaseEntityDto<long>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="jobId"></param>
        public CreateUpdateUserJobDto(long userId, long jobId)
        {
            UserId = userId;
            JobId = jobId;
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 岗位ID
        /// </summary>
        public long JobId { get; set; }
    }

}
