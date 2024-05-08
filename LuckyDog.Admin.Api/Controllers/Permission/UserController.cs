using LuckyDog.Admin.Api.Controllers.Base;
using LuckyDog.Admin.Common.Model;
using LuckyDog.Admin.Common.Webapp;
using LuckyDog.Admin.IBusiness.Dto.Permisson;
using LuckyDog.Admin.IBusiness.Interface.Permission;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace LuckyDog.Admin.Api.Controllers.Permission
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        
        private IUserService _userService;

        public UserController(IUserService userService ) 
        {
             _userService = userService;
             
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
          
            UserDto userDto =    await _userService.GetByNameAsync("guest");
            List<UserDto> users = new List<UserDto>(); 
            users.Add(userDto);
            return JsonContent(new ActionResultVm<UserDto>
            {
                Content = users,
                TotalElements = users.Count()
            });
        }
    }
}
