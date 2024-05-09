using LuckyDog.Admin.Business.Base;
using LuckyDog.Admin.Common.Exception;
using LuckyDog.Admin.Common.Extention;
using LuckyDog.Admin.Common.Model;
using LuckyDog.Admin.Common.SnowflakeIdHelper;
using LuckyDog.Admin.Common.Webapp;
using LuckyDog.Admin.Entity.Permission;
using LuckyDog.Admin.IBusiness.Base;
using LuckyDog.Admin.IBusiness.Dto.Permisson;
using LuckyDog.Admin.IBusiness.Interface.Permission;
using LuckyDog.Admin.IBusiness.QueryModel;
using Microsoft.AspNetCore.Http.HttpResults;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Business.Permission
{
    public class JobService : BaseService<Job> , IJobService
    {
        public JobService(ApeContext apeContext) : base(apeContext)
        {

        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="createUpdateJobDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> CreateAsync(CreateUpdateJobDto createUpdateJobDto)
        {
            // validate if name exsists 
            if( await TableWhere(j=>createUpdateJobDto.Name == j.Name ).AnyAsync())
            {
                throw  new  BadRequestException($"job name {createUpdateJobDto.Name} has exsisted .");
            }

            Job job =  ApeContext.Mapper.Map<Job>(createUpdateJobDto);

            job.Id= IdHelper.GetLongId();

            job.CreateTime = DateTime.Now;

            return  await AddEntityAsync(job);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> DeleteAsync(HashSet<long> ids)
        {

            List<Job>  jobs =   await TableWhere(j=> ids.Contains(j.Id)).Includes(x=>x.Users).ToListAsync();

            if (jobs.IsNullOrEmpty())
            {
                throw new BadRequestException("Data Does Not Exsist");
            }

            if( jobs.Any(j=> j.Users.Count>0 && j.Users!=null) ) 
            {
                throw new BadRequestException("Please Delete Asociation Users First");
            }
            return await LogicDelete<Job>(j=>ids.Contains(j.Id))>0;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="createUpdateJobDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> UpdateAsync(CreateUpdateJobDto createUpdateJobDto)
        {
            var oldJob = await TableWhere(j=>j.Id == createUpdateJobDto.Id).FirstAsync();

            if(oldJob.IsNull())
            {
                throw new  BadRequestException("Data Does Not Exsist");
            }
            
            if(oldJob.Name!= createUpdateJobDto?.Name && await TableWhere(j=>j.Name ==createUpdateJobDto.Name).AnyAsync()) 
            {

                throw new BadRequestException("Job Name Has Exsisted.");
            }

            var job = ApeContext.Mapper.Map<Job>(createUpdateJobDto);

            job.UpdateBy = ApeContext?.HttpContext?.User?.Identity?.Name;

            job.UpdateTime = DateTime.Now;

            return await UpdateEntityAsync(job);

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
            Expression<Func<Job, bool>> whereExpression = GetWhereExpression(jobQueryCriteria);

            List<Job> jobs = await SugarRepository.QueryPageListAsync(whereExpression, pagination);


            return ApeContext.Mapper.Map<List<JobDto>>(jobs);
             

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

            expressionable.And(j => true);

            expressionable.AndIF(!jobQueryCriteria.JobName.IsNullOrEmpty(), j => j.Name.Contains(jobQueryCriteria.JobName));

            expressionable.AndIF(!jobQueryCriteria.Enabled.IsNullOrEmpty(), j => j.Enabled == jobQueryCriteria.Enabled);

            expressionable.AndIF(!jobQueryCriteria.CreateTime.IsNullOrEmpty(), j => j.CreateTime >= jobQueryCriteria.CreateTime[0] && j.CreateTime <= jobQueryCriteria.CreateTime[1]);

            return expressionable.ToExpression();
        }
    }
}
