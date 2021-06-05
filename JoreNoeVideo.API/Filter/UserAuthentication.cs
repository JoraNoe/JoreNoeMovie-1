
using JoreNoeVideo.DomainServices.Tools;
using JoreNoeVideo.DomianServices;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoreNoeVideo.API.Filter
{
    public class UserAuthentication : ActionFilterAttribute
    {
        private readonly IUserDomainService UserDomainService;
        public UserAuthentication(IUserDomainService UserDomainService)
        {
            this.UserDomainService = UserDomainService;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ////获取token
            //var CurrentUserToken = context.HttpContext.Request.Headers["token"].ToString();
            //if (string.IsNullOrEmpty(CurrentUserToken))
            //    throw new ArgumentNullException(nameof(CurrentUserToken));

            ////使用Token  查询数据库 读取用户信息
            //var CurrentUserInfo = UserDomainService.FindUserByUserOpenId(CurrentUserToken);

            //if (CurrentUserInfo == null)
            //    throw new ArgumentNullException("当前用户数据为空");

        }
    }
}
