
using JoreNoeVideo.DomainServices.Tools;
using JoreNoeVideo.DomianServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoreNoeVideo.API.Filter
{
    public class UserAuthentication : ActionFilterAttribute, IAuthorizationFilter
    {

        private bool UseAuthorization { set; get; }

        public UserAuthentication(bool useAuthorization = false)
        {
            this.UseAuthorization = useAuthorization;
        }

        /// <summary>
        /// 授权验证
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            ////解析出对应的方法
            //if (!context.HttpContext.Request.Path.Value.Contains("Author"))
            //{
            //    ////获取token
            //    var CurrentUserToken = context.HttpContext.Request.Headers["token"].ToString();
            //    if (string.IsNullOrEmpty(CurrentUserToken))
            //    {
            //        //定义信息
            //        var ReturnResult = new
            //        {
            //            Status = StatusCodes.Status401Unauthorized,
            //            Title = "401",
            //            Time = DateTime.Now,
            //            Descript = "请带有有效的Token哦！"
            //        };
            //        context.Result = new JsonResult(ReturnResult);
            //    }
            //}
        }
    }
}
