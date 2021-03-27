using JoreNoeVideo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.Store
{
    public interface IDbContextFace<T> where T:class
    {
        Task<T> AddAsync(T t);
        Task<T> EditAsync(T t);
        Task<T> DeleteAsync(Guid Id);
        Task<T> GetSingle(Guid Id);
        Task<IList<T>> All();
        Task<IList<T>> Page(int PageNum = 0, int PageSize = 10);
    }
}
