
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JoreNoeVide.Store;
using System.Linq;
using JoreNoeVideo.Domain;

namespace JoreNoeVideo.Store
{
    public class DbContextFace<T> : IDbContextFace<T> where T : BaseModel, new()
    {

        private readonly JoreNoeVideoDbContext Db = new JoreNoeVideoDbContext();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public T Add(T t)
        {
            this.Db.Set<T>().Add(t);
            this.Db.SaveChanges();
            return t;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<T> AddAsync(T t)
        {
            await this.Db.Set<T>().AddAsync(t);
            this.Db.SaveChanges();
            return t;
        }
        /// <summary>
        /// 添加同步
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<T> AddRange(IList<T> t)
        {
            this.Db.Set<T>().AddRange(t);
            this.Db.SaveChanges();
            return t.ToList();
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<IList<T>> AddRangeAsync(IList<T> t)
        {
            await this.Db.Set<T>().AddRangeAsync(t);
            this.Db.SaveChanges();
            return t;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public async Task<IList<T>> AllAsync()
        {
            var Result = await this.Db.Set<T>().AsNoTracking().Where(d => true && !d.IsDelete).ToListAsync();
            return Result;
        }
        /// <summary>
        /// 删除同步
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T SoftDelete(Guid Id)
        {
            var Re = new T();
            if (!this.Db.Set<T>().Any(d => d.Id == Id))
                return null;
            Re = this.GetSingle(Id).Result;

            if (Re == null)
            {
                return null;
            }
            Re.IsDelete = true;
            var Result = this.Db.Set<T>().Update(Re);
            this.Db.SaveChanges();
            return Result.Entity;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<T> DeleteAsync(Guid Id)
        {
            var Result = this.Db.Set<T>().Remove(new T { Id = Id });
            this.Db.SaveChanges();
            return Task.Run(() => { return Result.Entity; });
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<T> DeleteRangeAsync(Guid Id)
        {
            throw new Exception();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Task<T> EditAsync(T t)
        {
            var Result = this.Db.Set<T>().Update(t);
            this.Db.SaveChanges();
            return Task.Run(() => { return Result.Entity; });
        }
        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<T> GetSingle(Guid Id)
        {
            return await this.Db.Set<T>().AsTracking().SingleAsync(d => d.Id == Id && !d.IsDelete);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="PageNum"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<IList<T>> Page(int PageNum = 0, int PageSize = 10)
        {
            var Result = await AllAsync();
            var Page = Result.Skip(PageNum - 1 * PageSize).Take(PageNum * PageSize);
            return Page.ToList();
        }
        /// <summary>
        /// 同步获取数据
        /// </summary>
        /// <returns></returns>
        public List<T> All()
        {
            return this.Db.Set<T>().AsNoTracking().Where(d => true && !d.IsDelete).ToList();
        }
        /// <summary>
        /// 硬删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T Delete(Guid Id)
        {
            var Re = new T();
            if (!this.Db.Set<T>().Any(d => d.Id == Id))
                return null;
            Re = this.GetSingle(Id).Result;
            this.Db.Set<T>().Remove(Re);
            this.Db.SaveChanges();
            return Re;
        }
    }
}
