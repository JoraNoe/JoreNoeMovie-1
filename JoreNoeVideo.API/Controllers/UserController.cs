using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JoreNoeVideo.API.Filter;
using JoreNoeVideo.CommonInterFaces;
using JoreNoeVideo.Domain.Models;
using JoreNoeVideo.DomianServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JoreNoeVideo.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(IUserDomainService UserDomainService)
        {
            this.userDomainService = UserDomainService;
        }
        private readonly IUserDomainService userDomainService;

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPost("AddUser")]
        public async Task<ActionResult<APIReturnInfo<User>>> AddUser([FromBody] User Model)
        {
            return APIReturnInfo<User>.Success(await this.userDomainService.AddUser(Model));
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPut("EditUser")]
        public async Task<ActionResult<APIReturnInfo<User>>> EditUser([FromBody] User Model)
        {
            return APIReturnInfo<User>.Success(await this.userDomainService.EditUser(Model));
        }
        /// <summary>
        /// 根据Id查询单条数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("SingleUser")]
        public async Task<ActionResult<APIReturnInfo<User>>> AddUser()
        {
            return APIReturnInfo<User>.Success(await this.userDomainService.SingleUser(Guid.Parse(this.UserId())));
        }
        /// <summary>
        /// 根据Id删除用户
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/DeleteUser")]
        public async Task<ActionResult<APIReturnInfo<User>>> Delete(Guid Id)
        {
            return APIReturnInfo<User>.Success(await this.userDomainService.RemoveUser(Id));
        }

        /// <summary>
        /// 授权根据Code 获取OpenId
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        [UserAuthentication(true)]
        [HttpGet("Authorization/{Code}")]
        public async Task<ActionResult<APIReturnInfo<string>>> Authorization(string Code)
        {
            return APIReturnInfo<string>.Success(await this.userDomainService.Authorization(Code));
        }
    }
}
