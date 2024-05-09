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
    public interface IApisService 
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="createUpdateApisDto"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(CreateUpdateApisDto createUpdateApisDto);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="createUpdateApisDto"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(CreateUpdateApisDto createUpdateApisDto);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(HashSet<long> ids);

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="apisQueryCriteria"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        Task<List<Apis>> QueryAsync(ApisQueryCriteria apisQueryCriteria, Pagination pagination);

        /// <summary>
        /// Query All
        /// </summary>
        /// <returns></returns>
        Task<List<Apis>> QueryAllAsync();

        /// <summary>
        /// Create in batch
        /// </summary>
        /// <param name="apis"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(List<Apis> apis);
    }
}
