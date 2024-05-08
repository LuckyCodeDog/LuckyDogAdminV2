using LuckyDog.Admin.Business.Base;
using LuckyDog.Admin.Common.Extention;
using LuckyDog.Admin.Common.Model;
using LuckyDog.Admin.Entity.Permission;
using LuckyDog.Admin.IBusiness.Dto.Permisson;
using LuckyDog.Admin.IBusiness.Interface.Permission;
using LuckyDog.Admin.IBusiness.QueryModel;
using SqlSugar;
using System.Linq.Expressions;

namespace LuckyDog.Admin.Api.Controllers.Permission
{
    public class JobService : BaseService<Job>, IJobService
    {

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="createUpdateJobDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> CreateAsync(CreateUpdateJobDto createUpdateJobDto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> DeleteAsync(HashSet<long> ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="createUpdateJobDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> UpdateAsync(CreateUpdateJobDto createUpdateJobDto)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Query All
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<JobDto>> QueryAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Query Condition
        /// </summary>
        /// <param name="jobQueryCriteria"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<JobDto>> QueryAsync(JobQueryCriteria jobQueryCriteria, Pagination pagination)
        {
             Expression<Func<Job,bool>> where =  GetWhereExpression(jobQueryCriteria);
        }



        /// <summary>
        /// Download
        /// </summary>
        /// <param name="jobQueryCriteria"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<ExportBase>> DownloadAsync(JobQueryCriteria jobQueryCriteria)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Build Query Expression
        /// </summary> 
        /// <param name="jobQueryCriteria"></param>
        /// <returns></returns>
        private Expression<Func<Job, bool>> GetWhereExpression(JobQueryCriteria jobQueryCriteria)
        {

            Expressionable<Job> expressionable = Expressionable.Create<Job>();
            
            expressionable.And(j=>true);

            expressionable.AndIF(!jobQueryCriteria.JobName.IsNullOrEmpty(), j=> j.Name.Contains(jobQueryCriteria.JobName));

            expressionable.AndIF(!jobQueryCriteria.Enabled.IsNullOrEmpty(), j => j.Enabled == jobQueryCriteria.Enabled);

            expressionable.AndIF(!jobQueryCriteria.CreateTime.IsNullOrEmpty(), j=> j.CreateTime >= jobQueryCriteria.CreateTime[0] && j.CreateTime <= jobQueryCriteria.CreateTime[1]);

            return expressionable.ToExpression();
        }
      
    }
}
