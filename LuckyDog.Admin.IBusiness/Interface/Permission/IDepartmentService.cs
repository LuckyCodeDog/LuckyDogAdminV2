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
    public interface IDepartmentService : IBaseServices<Department>
    {
        #region Basic Interfaces

        /// <summary>
        /// Create Department
        /// </summary>
        /// <param name="createUpdateDepartmentDto"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(CreateUpdateDepartmentDto createUpdateDepartmentDto);

        /// <summary>
        /// Update Department
        /// </summary>
        /// <param name="createUpdateDepartmentDto"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(CreateUpdateDepartmentDto createUpdateDepartmentDto);

        /// <summary>
        /// Delete Department
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(List<long> ids);

        /// <summary>
        /// Query Department
        /// </summary>
        /// <param name="deptQueryCriteria"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        Task<List<DepartmentDto>> QueryAsync(DeptQueryCriteria deptQueryCriteria, Pagination pagination);

        /// <summary>
        /// Download
        /// </summary>
        /// <param name="deptQueryCriteria"></param>
        /// <returns></returns>
        Task<List<ExportBase>> DownloadAsync(DeptQueryCriteria deptQueryCriteria);

        #endregion

        #region Extend Interfaces

        /// <summary>
        /// Query All Departments By Parent Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<DepartmentDto>> QueryByPIdAsync(long id);

        /// <summary>
        /// Query One Department By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DepartmentSmallDto> QueryByIdAsync(long id);


        /// <summary>
        /// Query All Parent Departments
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<List<DepartmentDto>> QuerySuperiorDeptAsync(HashSet<long> ids);

        /// <summary>
        /// Query All Children Departments
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="allIds"></param>
        /// <returns></returns>
        Task<List<long>> GetChildIds(List<long> ids, List<long> allIds);

        #endregion
    }
}
