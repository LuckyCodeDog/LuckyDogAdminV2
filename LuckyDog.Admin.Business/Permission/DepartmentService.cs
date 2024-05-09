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
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {

        #region Constructor
        public DepartmentService(ApeContext apeContext):base(apeContext) 
        { 
        
        }
        #endregion

        #region Basic Interfaces
        /// <summary>
        /// Create Department
        /// </summary>
        /// <param name="createUpdateDepartmentDto"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        public async Task<bool> CreateAsync(CreateUpdateDepartmentDto createUpdateDepartmentDto)
        {
            if( await TableWhere(d=>d.Name == createUpdateDepartmentDto.Name).AnyAsync())
            {
                throw new BadRequestException($"Name: {createUpdateDepartmentDto.Name} Has Exsisted ");
            }

            var dep =  ApeContext.Mapper.Map<Department>(createUpdateDepartmentDto);

            await AddEntityAsync(dep);
            //main its parents sub count 
            if(dep.ParentId !=0)
            {
                var parentDep =  await TableWhere(d=>d.Id == dep.ParentId).FirstAsync();   
                if(parentDep.IsNotNull())
                {
                    var count = await TableWhere(d=>d.ParentId == parentDep.ParentId).CountAsync();
                    dep.SubCount = count;
                    
                   await UpdateEntityAsync(dep);
                }

            }
            
            return true;
        }


        /// <summary>
        /// Logic Delete Departments In Batch
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> DeleteAsync(List<long> ids)
        {
            List<Department> departments = await TableWhere(d=>ids.Contains(d.Id)).ToListAsync();
            if(departments.Count <= 0)
            {
                throw new BadRequestException("Data Does Not Exsist");
            }

            return await LogicDelete<Department>(d=>ids.Contains(d.Id))>0;

        }

        public Task<List<ExportBase>> DownloadAsync(DeptQueryCriteria deptQueryCriteria)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Query Departments
        /// </summary>
        /// <param name="deptQueryCriteria"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<DepartmentDto>> QueryAsync(DeptQueryCriteria deptQueryCriteria, Pagination pagination)
        {
             Expression<Func<Department, bool>> expression =  GetWhereExpression(deptQueryCriteria);

            List<Department> departments;
            if (deptQueryCriteria.ParentId.IsNull())
            {
               departments = await SugarRepository.QueryPageListAsync(expression,pagination);
            }
            else
            {
                departments = await SugarRepository.QueryListAsync(expression);
            }

            
             pagination.TotalElements = departments.Count;

             List<DepartmentDto> departmentDtos = ApeContext.Mapper.Map<List<DepartmentDto>>(departments);

            return departmentDtos;
                
        }

        public Task<bool> UpdateAsync(CreateUpdateDepartmentDto createUpdateDepartmentDto)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Extend Interfaces
        public Task<List<long>> GetChildIds(List<long> ids, List<long> allIds)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentSmallDto> QueryByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DepartmentDto>> QueryByPIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DepartmentDto>> QuerySuperiorDeptAsync(HashSet<long> ids)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Where Expression
        private Expression<Func<Department, bool>> GetWhereExpression(DeptQueryCriteria deptQueryCriteria)
        {
            Expressionable<Department> expressionable = Expressionable.Create<Department>();

            expressionable.And(d => true);
             
            expressionable.AndIF(deptQueryCriteria.ParentId.IsNotNull(), d=>d.ParentId == deptQueryCriteria.ParentId);

            expressionable.AndIF(deptQueryCriteria.ParentId.IsNull(), d => d.ParentId == 0);

            expressionable.AndIF(!deptQueryCriteria.DeptName.IsNullOrEmpty() , d=>d.Name.Contains(deptQueryCriteria.DeptName));

            expressionable.AndIF(!deptQueryCriteria.Enabled.IsNullOrEmpty(), d=>d.Enabled ==deptQueryCriteria.Enabled);

            expressionable.AndIF(!deptQueryCriteria.CreateTime.IsNullOrEmpty() && deptQueryCriteria.CreateTime.Count == 2,
                d => d.CreateTime >= deptQueryCriteria.CreateTime[0] && d.CreateTime <= deptQueryCriteria.CreateTime[1]);
            
            return expressionable.ToExpression();

        }
        #endregion
    }
}
