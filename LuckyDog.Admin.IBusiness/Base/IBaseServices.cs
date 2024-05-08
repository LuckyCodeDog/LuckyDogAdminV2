using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuckyDog.Admin.Common;
using LuckyDog.Admin.Common.Webapp;
using System.Linq.Expressions;
using LuckyDog.Admin.Repository.SugarHandler;
using LuckyDog.Admin.Common.Model;
namespace LuckyDog.Admin.IBusiness.Base
{
    public interface IBaseServices<TEntity> where TEntity : class
    {

        ISqlSugarClient sqlSugarClient { get; }
        ApeContext ApeContext { get; }

        #region Add
        /// <summary>
        /// Add Entity 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> AddEntityAsync(TEntity entity);

        /// <summary>
        /// Add Entity List 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<bool> AddEntityListAsync(List<TEntity> entities);
        #endregion

        #region Update
        /// <summary>
        ///Update Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="lstIgnoreColumns"></param>
        /// <param name="isLock"></param>
        /// <returns></returns>
        Task<bool> UpdateEntityAsync(TEntity entity, List<string>? lstIgnoreColumns = null, bool isLock = true);
        /// <summary>
        /// Update Entity List 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<bool> UpdateEntityListAsync(List<TEntity> entities);

        #endregion

        #region Delete
        /// <summary>
        /// logic delete
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<int> LogicDelete<T>(Expression<Func<T, bool>> expression) where T : class, ISoftDeletedEntity, new();
        #endregion

        #region Queryable
        /// <summary>
        /// Generic Queryable 
        /// </summary>
        ISugarQueryable<TEntity> Table {  get; }
        /// <summary>
        /// Generic Queryable 
        /// </summary>
        /// <param name="whereExpression">Query Condition</param>
        /// <param name="orderExpression">Oder Expression</param>
        /// <param name="orderByType">Order Way</param>
        /// <returns></returns>
        ISugarQueryable<TEntity> TableWhere(
             Expression<Func<TEntity, bool>>? whereExpression = null
            ,Expression<Func<TEntity, object>>? orderExpression = null
            ,OrderByType orderByType = OrderByType.Desc
            );
        #endregion
    }
}
