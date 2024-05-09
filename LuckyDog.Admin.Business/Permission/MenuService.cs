using LuckyDog.Admin.Business.Base;
using LuckyDog.Admin.Entity.Permission;
using LuckyDog.Admin.IBusiness.Base;
using LuckyDog.Admin.IBusiness.Dto.Permisson;
using LuckyDog.Admin.IBusiness.Interface.Permission;
using LuckyDog.Admin.IBusiness.QueryModel;
using LuckyDog.Admin.IBusiness.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Business.Permission
{
    public class MenuService : BaseService<Menu>, IMenuService
    {

        #region Basic Interfaces
        public async Task<bool> CreateAsync(CreateUpdateMenuDto createMenuDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(HashSet<long> ids)
        {
            throw new NotImplementedException();
        }

        public Task<List<MenuDto>> QueryAsync(MenuQueryCriteria menuQueryCriteria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CreateUpdateMenuDto updateMenuDto)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Extend Interfaces

        public Task<List<MenuTreeVo>> BuildTreeAsync(long userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<MenuDto>> FindByPIdAsync(long pid = 0)
        {
            throw new NotImplementedException();
        }

        public Task<List<long>> FindChildAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MenuDto>> FindSuperiorAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MenuDto>> QueryAllAsync()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
