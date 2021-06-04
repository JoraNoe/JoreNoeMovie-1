using JoreNoeVideo.DomainServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoreNoeVideo.API.Filter
{
    public static class UserInfo
    {
        /// <summary>
        /// 获取用户Id
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        public static string UserId(this ControllerBase controller)
        {
            //创建对象 
            UserHelper User = new UserHelper();
            //获取token
            var CurrentUserToken = controller.HttpContext.Request.Headers["token"].ToString();
            if (string.IsNullOrEmpty(CurrentUserToken))
                throw new ArgumentNullException(nameof(CurrentUserToken));

            //使用Token  查询数据库 读取用户信息
            var CurrentUserInfo = User.FindUserByUserOpenId(CurrentUserToken);

            if (CurrentUserInfo == null)
                throw new ArgumentNullException("当前用户数据为空");
            return CurrentUserInfo.Id.ToString();
        }

    }
}
