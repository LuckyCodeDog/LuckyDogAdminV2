using LuckyDog.Admin.Api.Controllers.Base;
using LuckyDog.Admin.Common.Extention;
using LuckyDog.Admin.Common.Model;
using LuckyDog.Admin.Entity.Permission;
using LuckyDog.Admin.IBusiness.Dto.Permisson;
using LuckyDog.Admin.IBusiness.Interface.Permission;
using LuckyDog.Admin.IBusiness.QueryModel;
using LuckyDog.Admin.IBusiness.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace LuckyDog.Admin.Api.Controllers.Permission
{

    [Route("/api/department")]
    public class DepartmentController : BaseApiController
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("query")]
        public async Task<ActionResult> QueryAsync(DeptQueryCriteria deptQueryCriteria, Pagination pagination)
        {

            var deps = await _departmentService.QueryAsync(deptQueryCriteria, pagination);

            return JsonContent(new ActionResultVm<DepartmentDto>()
            {
                Content = deps,
                TotalElements = pagination.TotalElements,
            });

        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateAsync(CreateUpdateDepartmentDto createUpdateDepartmentDto)
        {
            if (!ModelState.IsValid)
            {
                return Error(ModelState.GetErrors());
            }

            await _departmentService.UpdateAsync(createUpdateDepartmentDto);

            return Success();

        }

        [HttpPost]
        [Route("create")] 
        public async Task<ActionResult> CreateAsync(CreateUpdateDepartmentDto createUpdateDepartmentDto)
        {
            if(!ModelState.IsValid)
            {
                return Error(ModelState.GetErrors());   
            }

            await _departmentService.CreateAsync(createUpdateDepartmentDto);

            return Create();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteAsync(IdCollection idCollection)
        {
            if (!ModelState.IsValid)
            {
                return Error(ModelState.GetErrors());
            }

            List<long> ids = new List<long>(idCollection.IdArray);

            await  _departmentService.DeleteAsync(ids);

            return Success();
        }
    }
}
