using LuckyDog.Admin.Business.Base;
using LuckyDog.Admin.Common.Model;
using LuckyDog.Admin.Common.Webapp;
using LuckyDog.Admin.Entity.Permission;
using LuckyDog.Admin.IBusiness.Dto.Permisson;
using LuckyDog.Admin.IBusiness.Interface.Permission;
using LuckyDog.Admin.IBusiness.QueryModel;
using Microsoft.AspNetCore.Http;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDog.Admin.Business.Permission
{
    public class UserService : BaseService<User>, IUserService
    {


        public UserService(ApeContext apeContext): base(apeContext) 
        {

        }

        #region Basic Functions
        public Task<bool> CreateAsync(CreateUpdateUserDto createUpdateUserDto)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateAsync(UpdateUserCenterDto updateUserCenterDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteAsync(HashSet<long> ids)
        {
            throw new NotImplementedException();
        }
        public Task<List<UserDto>> QueryAsync(UserQueryCriteria userQueryCriteria, Pagination pagination)
        {
            throw new NotImplementedException();
        }

        public Task<List<ExportBase>> DownloadAsync(UserQueryCriteria userQueryCriteria)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Extended Function
        public Task<UserDto> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetByNameAsync(string userName)
        {
                User  user = await SugarRepository.QueryFirstAsync(u=>u.Username == userName); 
                return   ApeContext.Mapper.Map<User, UserDto>(user);
        }

        public Task<List<UserDto>> QueryByDeptIdsAsync(List<long> ids)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePasswordAsync(UpdateUserPassDto updateUserPassDto)
        {
            throw new NotImplementedException();
        }


        public Task<bool> UpdateEmailAsync(UpdateUserEmailDto updateUserEmailDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAvatarAsync(IFormFile file)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region User Cache 

        #endregion

        #region QueryCeterial Expression
        #endregion








    }
}
