using LuckyDog.Admin.Common.Model;
using LuckyDog.Admin.Entity.Permission;
using LuckyDog.Admin.IBusiness.Base;
using LuckyDog.Admin.IBusiness.Dto.Permisson;
using LuckyDog.Admin.IBusiness.QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.Interface.Permission
{
    public  interface  IJobService : IBaseServices<Job>
    {
        #region Basic Interfaces
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="createUpdateJobDto"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(CreateUpdateJobDto createUpdateJobDto);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="updateUserCenterDto"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(CreateUpdateJobDto createUpdateJobDto);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(HashSet<long> ids);

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="jobQueryCriteria"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        Task<List<JobDto>> QueryAsync(JobQueryCriteria jobQueryCriteria, Pagination pagination);

        /// <summary>
        /// Download
        /// </summary>
        /// <param name="jobQueryCriteria"></param>
        /// <returns></returns>
        Task<List<ExportBase>> DownloadAsync(JobQueryCriteria jobQueryCriteria);
        #endregion


        #region Extend Interfaces
         /// <summary>
         /// Query All
         /// </summary>
         /// <returns></returns>
        Task<List<JobDto>> QueryAllAsync();
        #endregion
    }
}
