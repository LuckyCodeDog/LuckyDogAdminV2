using LuckyDog.Admin.Common.Model;
using LuckyDog.Admin.Entity.Permission;
using LuckyDog.Admin.IBusiness.Base;
using LuckyDog.Admin.IBusiness.Dto.Permisson;
using LuckyDog.Admin.IBusiness.QueryModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.IBusiness.Interface.Permission
{
    public interface IUserService  : IBaseServices<User>
    {
        #region Basic Interface 
        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="createUpdateUserDto"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(CreateUpdateUserDto createUpdateUserDto);

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="updateUserCenterDto"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(UpdateUserCenterDto updateUserCenterDto);

        /// <summary>
        /// Logic Delete
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<bool?> DeleteAsync(HashSet<long> ids);

        /// <summary>
        /// Query
        /// </summary>
        /// <param name="userQueryCriteria"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        Task<List<UserDto>> QueryAsync(UserQueryCriteria userQueryCriteria, Pagination pagination);

        /// <summary>
        /// Export and Download
        /// </summary>
        /// <param name="userQueryCriteria"></param>
        /// <returns></returns>
        Task<List<ExportBase>> DownloadAsync(UserQueryCriteria userQueryCriteria);
        #endregion

        #region Extended Interface 
        /// <summary>
        /// Query By Id 
        /// </summary>
        /// <param name="id">user id </param>
        /// <returns></returns>
        Task<UserDto> GetByIdAsync(long id);

        /// <summary>
        /// Query By User Name 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<UserDto> GetByNameAsync(string userName);

        /// <summary>
        /// Query By Dep Id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<List<UserDto>> QueryByDeptIdsAsync(List<long> ids);

        /// <summary>
        /// Update Password
        /// </summary>
        /// <param name="updateUserPassDto"></param>
        /// <returns></returns>
        Task<bool> UpdatePasswordAsync(UpdateUserPassDto updateUserPassDto);

        /// <summary>
        /// Update Email
        /// </summary>
        /// <param name="updateUserEmailDto"></param>
        /// <returns></returns>
        Task<bool> UpdateEmailAsync(UpdateUserEmailDto updateUserEmailDto);


        /// <summary>
        /// Update Avatar 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<bool> UpdateAvatarAsync(IFormFile file);
        #endregion
    }
}
