using LuckyDog.Admin.Common.Model;
using LuckyDog.Admin.Common.Webapp;
using LuckyDog.Admin.IBusiness.Base;
using LuckyDog.Admin.Repository.SugarHandler;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Business.Base
{
    public class BaseService<TEntity> : IBaseServices<TEntity> where TEntity : class
    {


        public ISugarRepository<TEntity>?  SugarRepository { get; set; }

        public ISqlSugarClient sqlSugarClient => SugarRepository._sqlSugarClient;

        public ApeContext? ApeContext {  get; }

     
        public BaseService( ApeContext? apeContext =null, ISugarRepository<TEntity>? sugarRepository =null) {
            ApeContext = apeContext;
            SugarRepository = sugarRepository;
        }

        #region Add
        public async Task<bool> AddEntityAsync(TEntity entity)
        {
            return await SugarRepository.AddReturnBoolAsync(entity);
        }

        public async Task<bool> AddEntityListAsync(List<TEntity> entities)
        {
            return await SugarRepository.AddReturnBoolAsync(entities);
        }
        #endregion

        #region Update
        public async Task<bool> UpdateEntityAsync(TEntity entity, List<string>? lstIgnoreColumns = null, bool isLock = true)
        {
            return await SugarRepository.UpdateAsync(entity, lstIgnoreColumns, isLock) > 0;
        }

        public async Task<bool> UpdateEntityListAsync(List<TEntity> entities)
        {
            return await SugarRepository.UpdateAsync(entities) > 0;
        }

        #endregion

        #region Delete
        public async Task<int> LogicDelete<T>(Expression<Func<T, bool>> expression) where T : class, ISoftDeletedEntity, new()
        {
            return await sqlSugarClient.Updateable<T>()
                .Where(expression)
                .SetColumns(t => new T() { IsDeleted = true })
                .ExecuteCommandAsync();
        }
        #endregion

        #region Queryable
        /// <summary>
        /// Query By Condition
        /// </summary>
        /// <param name="whereExpression">Where Expression</param>
        /// <param name="orderExpression"></param>
        /// <param name="orderByType"></param>
        /// <returns></returns>
        public ISugarQueryable<TEntity> TableWhere(Expression<Func<TEntity, bool>>? whereExpression = null, Expression<Func<TEntity, object>>? orderExpression = null, OrderByType orderByType = OrderByType.Desc)
        {
            return sqlSugarClient.Queryable<TEntity>().WhereIF(whereExpression != null, whereExpression).OrderByIF(orderExpression != null, orderExpression, orderByType);
        }
        public ISugarQueryable<TEntity> Table => sqlSugarClient.Queryable<TEntity>();
        #endregion


    }
}
