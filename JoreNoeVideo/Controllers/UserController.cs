using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult<APIReturnInFo<User>>> AddUser([FromBody] User Model)
        {
            return APIReturnInFo<User>.Success(await this.userDomainService.AddUser(Model));
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPut("EditUser")]
        public async Task<ActionResult<APIReturnInFo<User>>> EditUser([FromBody] User Model)
        {
            return APIReturnInFo<User>.Success(await this.userDomainService.EditUser(Model));
        }
        /// <summary>
        /// 根据Id查询单条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("SingleUser/{Id}")]
        public async Task<ActionResult<APIReturnInFo<User>>> AddUser(Guid Id)
        {
            return APIReturnInFo<User>.Success(await this.userDomainService.SingleUser(Id));
        }
        /// <summary>
        /// 根据Id删除用户
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}/DeleteUser")]
        public async Task<ActionResult<APIReturnInFo<User>>> Delete(Guid Id)
        {
            return APIReturnInFo<User>.Success(await this.userDomainService.RemoveUser(Id));
        }
    }
}
