using LuckyDog.Admin.Api.Controllers.Base;
using LuckyDog.Admin.Business.Base;
using LuckyDog.Admin.Common.Exception;
using LuckyDog.Admin.Common.Extention;
using LuckyDog.Admin.Common.Model;
using LuckyDog.Admin.Entity.Permission;
using LuckyDog.Admin.IBusiness.Dto.Permisson;
using LuckyDog.Admin.IBusiness.Interface.Permission;
using LuckyDog.Admin.IBusiness.QueryModel;
using LuckyDog.Admin.IBusiness.RequestModel;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System.Linq.Expressions;

namespace LuckyDog.Admin.Api.Controllers.Permission
{

    [Route("/api/job", Order =6 )]
    public class JobController : BaseApiController
    {
        #region fields

        private readonly IJobService _jobService;
        #endregion

        #region constructor
        public JobController(IJobService jobService) 
        {
            _jobService = jobService;
        }
        #endregion

        /// <summary>
        /// Query Jobs
        /// </summary>
        /// <param name="jobQueryCriteria"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
      [HttpGet]
      [Route("query")]

      public async Task<ActionResult> Query(JobQueryCriteria jobQueryCriteria , Pagination pagination)
      {
           List<JobDto> jobs = await _jobService.QueryAsync(jobQueryCriteria, pagination);

            return JsonContent( new ActionResultVm<JobDto>
            {
                Content = jobs,
                TotalElements = jobs.Count,
            });
      }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="createUpdateJobDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(CreateUpdateJobDto createUpdateJobDto)
        {
            if (!ModelState.IsValid)
            {
                return Error(ModelState.GetErrors());
            }
            
             await _jobService.CreateAsync(createUpdateJobDto);

            return Create();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="idCollection"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> Delete([FromBody] IdCollection idCollection )
        {
            if(!ModelState.IsValid)
            {
                return Error(ModelState.GetErrors());
            }
            await _jobService.DeleteAsync(idCollection.IdArray);
            return Success();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="createUpdateJobDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> Update(CreateUpdateJobDto createUpdateJobDto)
        {
            if (!ModelState.IsValid)
            {
                return Error(ModelState.GetErrors());
            }

            await _jobService.UpdateAsync(createUpdateJobDto);
            return Success();
        }
    }
}
