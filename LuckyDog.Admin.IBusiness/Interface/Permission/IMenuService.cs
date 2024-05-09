using LuckyDog.Admin.Entity.Permission;
using LuckyDog.Admin.IBusiness.Base;
using LuckyDog.Admin.IBusiness.Dto.Permisson;
using LuckyDog.Admin.IBusiness.QueryModel;
using LuckyDog.Admin.IBusiness.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.Interface.Permission
{
    public interface IMenuService : IBaseServices<Menu>
    {
        #region Basic Interfaces
        Task<bool> CreateAsync(CreateUpdateMenuDto createMenuDto);

        Task<bool> DeleteAsync(HashSet<long> ids);

        Task<List<MenuDto>> QueryAsync(MenuQueryCriteria menuQueryCriteria);

        Task<bool> UpdateAsync(CreateUpdateMenuDto updateMenuDto);
        #endregion

        #region Extend Interfaces
        /// <summary>
        /// Query All Menus
        /// </summary>
        /// <returns></returns>
        Task<List<MenuDto>> QueryAllAsync();

        /// <summary>
        /// Find Menus By Parent Id
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        Task<List<MenuDto>> FindByPIdAsync(long pid = 0);


        /// <summary>
        /// Build Menu Tree
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        Task<List<MenuTreeVo>> BuildTreeAsync(long userId);

        /// <summary>
        /// Query superior menu and Menus in same level
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<MenuDto>> FindSuperiorAsync(long id);

        /// <summary>
        /// find all children menus
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<long>> FindChildAsync(long id);
        #endregion
    }
}
