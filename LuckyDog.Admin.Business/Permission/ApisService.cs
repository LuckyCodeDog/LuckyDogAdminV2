using LuckyDog.Admin.Business.Base;
using LuckyDog.Admin.Common.Exception;
using LuckyDog.Admin.Common.Extention;
using LuckyDog.Admin.Common.Model;
using LuckyDog.Admin.Common.Webapp;
using LuckyDog.Admin.Entity.Permission;
using LuckyDog.Admin.IBusiness.Dto.Permisson;
using LuckyDog.Admin.IBusiness.Interface.Permission;
using LuckyDog.Admin.IBusiness.QueryModel;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Business.Permission
{
    public class ApisService : BaseService<Apis> , IApisService
    {

        #region Costor
        public ApisService(ApeContext apeContext):base(apeContext)
        { 
        }
        #endregion

        #region Basic Interfaces

        /// <summary>
        /// create one api
        /// </summary>
        /// <param name="createUpdateApisDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> CreateAsync(CreateUpdateApisDto createUpdateApisDto)
        {
             if( await TableWhere(a=>a.Url == createUpdateApisDto.Url).AnyAsync())
             {
                throw new BadRequestException("Path has exsisted.");
             }
             Apis api =   ApeContext.Mapper.Map<Apis>(createUpdateApisDto);
             
             return await AddEntityAsync(api);
        }

        /// <summary>
        /// create in batch
        /// </summary>
        /// <param name="apis"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> CreateAsync(List<Apis> apis)
        {
            return await AddEntityListAsync(apis);
        }

        /// <summary>
        /// Logic Delete 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> DeleteAsync(HashSet<long> ids)
        {
            List<Apis> apis =   await TableWhere(a=> ids.Contains(a.Id)).ToListAsync();
            if(apis.Count <= 0)
            {
                throw new BadRequestException("Data Does Not Exsist.");
            }
            return await LogicDelete<Apis>(a=>ids.Remove(a.Id))>0;

        }

        /// <summary>
        /// Query All
        /// </summary>
        /// <returns></returns>
        public async Task<List<Apis>> QueryAllAsync()
        {
            return await Table.ToListAsync();
        }

        /// <summary>
        /// Query With Condition
        /// </summary>
        /// <param name="apisQueryCriteria"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public async Task<List<Apis>> QueryAsync(ApisQueryCriteria apisQueryCriteria, Pagination pagination)
        {
            var whereExpression = GetWhereExpression(apisQueryCriteria);
            return  await SugarRepository.QueryPageListAsync(whereExpression, pagination);
        }

        /// <summary>
        /// Update 
        /// </summary>
        /// <param name="createUpdateApisDto"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        public async Task<bool> UpdateAsync(CreateUpdateApisDto createUpdateApisDto)
        {
            var oldApi = await TableWhere(a=>a.Id == createUpdateApisDto.Id).FirstAsync();

            if(oldApi == null)
            {
                throw new BadRequestException("Data Does Not Exsisted.");
            }

            if(oldApi.Url !=createUpdateApisDto.Url &&  await TableWhere(a=>a.Url==createUpdateApisDto.Url).AnyAsync())
            {
                throw new BadRequestException($"Url {oldApi.Url} Has Exsisted.");
            }

            var api =  ApeContext.Mapper.Map<Apis>(createUpdateApisDto);

            return await UpdateEntityAsync(api);
        }
        #endregion

        #region where expression
        /// <summary>
        /// Handle Query Criteria
        /// </summary>
        /// <param name="queryCriteria"></param>
        /// <returns></returns>
        private Expression<Func<Apis, bool>> GetWhereExpression(ApisQueryCriteria queryCriteria)
        {
            var expressionable = Expressionable.Create<Apis>();

            expressionable.And(a=>true);

            expressionable.AndIF(!queryCriteria.Group.IsNullOrEmpty(), a=>a.Group.Contains(queryCriteria.Group));

            expressionable.AndIF(!queryCriteria.Description.IsNullOrEmpty(), a => a.Description.Contains(queryCriteria.Description));  

            expressionable.AndIF(!queryCriteria.Method.IsNullOrEmpty(), a=> a.Method==queryCriteria.Method);    

            return expressionable.ToExpression();
 
        }
        #endregion

    }
}
