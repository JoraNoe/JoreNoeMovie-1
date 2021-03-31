using JoreNoeVideo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoreNoeVideo.Store
{
    public interface IDbContextFace<T> where T : class
    {
        #region 异步数据
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<T> AddAsync(T t);
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<IList<T>> AddRangeAsync(IList<T> t);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<T> EditAsync(T t);
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<T> DeleteAsync(Guid Id);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<T> DeleteRangeAsync(Guid Id);
        /// <summary>
        /// 获取单个数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<T> GetSingle(Guid Id);
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns></returns>
        Task<IList<T>> AllAsync();
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        Task<IList<T>> Page(int PageNum = 0, int PageSize = 10);
        #endregion
        #region 同步 数据

        /// <summary>
        /// 添加同步
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        T Add(T t);

        /// <summary>
        /// 移除 同步 软删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T SoftDelete(Guid Id);
        /// <summary>
        /// 批量添加同步
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        List<T> AddRange(IList<T> t);
        /// <summary>
        /// 全部数据同步
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        List<T> All();
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T Delete(Guid Id);
        #endregion


    }
}
