using JoreNoeVideo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JoreNoeVideo.DomianServices
{
    public interface IUserDomainService
    {
        Task<User> AddUser(User Model);
        Task<User> EditUser(User Model);
        Task<User> RemoveUser(Guid Id);
        Task<User> SingleUser(Guid Id);
        Task<IList<User>> AllUser();
    }
}
