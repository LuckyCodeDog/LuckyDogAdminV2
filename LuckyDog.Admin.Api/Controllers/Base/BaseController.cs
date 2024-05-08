using LuckyDog.Admin.Common.Extention;
using LuckyDog.Admin.Common.Model;
using Microsoft.AspNetCore.Mvc;

namespace LuckyDog.Admin.Api.Controllers.Base
{
    public class BaseController: ControllerBase
    {
        /// <summary>
        /// return json content
        /// </summary>
        /// <param name="actionResultVm"></param>
        /// <returns></returns>
        private ContentResult JsonContent(ActionResultVm actionResultVm)
        {
            return new ContentResult
            {
                Content = new ActionResultVm
                {
                    Status = actionResultVm.Status,
                    ActionError = actionResultVm.ActionError,
                    Message = actionResultVm.Message,
                    TimeStamp = DateTime.Now.ToUniversalTime().ToString(),
                    Path = Request.Path.ToString().ToLower(),
                    /// to json
                }.ToJson(),
                ContentType = "application/json; charset=utf-8",
                StatusCode = actionResultVm.Status,
            };
        }

        /// <summary>
        /// return json  
        /// </summary>
        /// <param name="obj">obj type</param>
        /// <returns></returns>
        protected ContentResult JsonContent(object obj)
        {
            return new ContentResult
            {
                Content = obj.ToJson(),
                ContentType = "application/json; charset=utf-8",
                StatusCode = StatusCodes.Status200OK
            };
        }

        /// <summary>
        /// return success
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected ContentResult Success(string msg = "")
        {
            msg = msg.IsNullOrEmpty() ? "Request Success": msg;

            var vm = new ActionResultVm
            {
                Message = msg,
                Status = StatusCodes.Status200OK,
            };
            return JsonContent(vm);
        }

        /// <summary>
        /// Created Success
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected ContentResult Create(string msg = "")
        {
            msg = msg.IsNullOrEmpty()? "Create Success": msg;
            var vm = new ActionResultVm
            {
                Message = msg,
                Status = StatusCodes.Status201Created,
            };
            return JsonContent(vm); 
        }

        /// <summary>
        /// Update Success With Out Content
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected ContentResult NoContent(string msg = "")
        {
            return new ContentResult
            {
                ContentType = "application/json; charset=utf-8",
                StatusCode = StatusCodes.Status204NoContent,
            };
        }

        /// <summary>
        /// Return Errors Message Without Content
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected ContentResult Error(string msg = "")
        {
            msg = msg.IsNullOrEmpty() ? "Request Failed" : msg;
            var vm = new ActionResultVm
            {
                Status = StatusCodes.Status400BadRequest,
                Message = msg,
                ActionError = new ActionError(),

            };
            return JsonContent(vm);
        }

        /// <summary>
        /// Return Errors With Content
        /// </summary>
        /// <param name="actionError"></param>
        /// <returns></returns>
        protected ContentResult Error(ActionError actionError)
        {
            var vm = new ActionResultVm
            {
                Status = StatusCodes.Status400BadRequest,
                Message = actionError.GetFirstError(),
                ActionError = new ActionError(),
            };
            return JsonContent(vm);
        }
    }
}
