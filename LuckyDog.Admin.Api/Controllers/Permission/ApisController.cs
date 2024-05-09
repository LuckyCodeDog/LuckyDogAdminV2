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
    [Route("/api/apis",Order=20)]
    public class ApisController : BaseApiController
    {
        #region fields
        private readonly IApisService _apisService;
        #endregion

        #region constructor
        public ApisController(IApisService apisService) 
        {
            _apisService = apisService;
        }
        #endregion

        [HttpGet]
        [Route("query")]
        public async Task<ActionResult> QueryAsync(ApisQueryCriteria apisQueryCriteria,Pagination pagination)
        {
            if(!ModelState.IsValid) 
            {
                return Error(ModelState.GetErrors());
            }
            List<Apis> apis =   await _apisService.QueryAsync(apisQueryCriteria, pagination);

            return JsonContent(apis);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateAsync(CreateUpdateApisDto createUpdateApisDto)
        {
            if(!ModelState.IsValid) 
            {
                return Error(ModelState.GetErrors());
            }

            await _apisService.CreateAsync(createUpdateApisDto);

            return Create();
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateAsync(CreateUpdateApisDto createUpdateApisDto)
        {
            if(!ModelState.IsValid)
            {
                return Error(ModelState.GetErrors());
            }

            await _apisService.UpdateAsync(createUpdateApisDto);

            return Success();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteAsync(IdCollection idCollection)
        {
            if (!ModelState.IsValid)
            {
                return Error(ModelState.GetErrors());
            }

            await _apisService.DeleteAsync(idCollection.IdArray);

            return Success();
        }
    }
}
