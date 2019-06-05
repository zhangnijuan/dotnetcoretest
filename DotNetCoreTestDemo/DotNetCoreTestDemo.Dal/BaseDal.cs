using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DotNetCoreTestDemo.IDal;
using DotNetCoreTestDemo.Model;
using Microsoft.EntityFrameworkCore;
using Common;

namespace DotNetCoreTestDemo.Dal
{
    public class BaseDal<T> :IBaseDal<T> where T:class 
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public BaseDal(DbContext dbContext)
        {
            this._dbContext=  dbContext;
            _dbSet = this._dbContext.Set<T>();
        }
        #region 插入数据
        public bool Insert(T entity)
        {
            this._dbSet.Add(entity);
            return this._dbContext.SaveChanges() > 0;
        }

        public bool Insert(List<T> entities)
        {
            this._dbSet.AddRange(entities);
            return this._dbContext.SaveChanges() > 0;
        }

        public async Task<bool> InsertAsync(T entity)
        {
            this._dbSet.Add(entity);
            return await this._dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> InsertAsync(List<T> entities)
        {
            this._dbSet.AddRange(entities);
            return await this._dbContext.SaveChangesAsync() > 0;
        }
        #endregion

        #region 更新数据
        public bool Update(T entity, List<string> updatePropertyList = null, bool modified = true)
        {
            if (entity == null) return false;
            this._dbSet.Attach(entity);
            var entry = this._dbContext.Entry(entity);
            if (updatePropertyList == null)
            {
                entry.State = EntityState.Modified;
            }
            else
            {
                if (modified)
                {
                    updatePropertyList.ForEach(i =>
                    {
                        entry.Property(i).IsModified = true;
                    });
                }
                else
                {
                    entry.State = EntityState.Modified;
                    updatePropertyList.ForEach(i =>
                    {
                        entry.Property(i).IsModified = false;
                    });
                }
            }

            return this._dbContext.SaveChanges() > 0;
        }

        public async Task<bool> UpdateAsync(T entity, List<string> updatePropertyList = null, bool modified = true)
        {
            if (entity == null) return false;
            this._dbSet.Attach(entity);
            var entry = this._dbContext.Entry(entity);
            if (updatePropertyList == null)
            {
                entry.State = EntityState.Modified;
            }
            else
            {
                if (modified)
                {
                    updatePropertyList.ForEach(i =>
                    {
                        entry.Property(i).IsModified = true;
                    });
                }
                else
                {
                    entry.State = EntityState.Modified;
                    updatePropertyList.ForEach(i =>
                    {
                        entry.Property(i).IsModified = false;
                    });
                }
            }

            return await this._dbContext.SaveChangesAsync() > 0;
        }

        public bool Update(List<T> entities)
        {
            if (entities == null || entities.Count <= 0)
            {
                return false;
            }
            entities.ForEach(i =>
            {
                this._dbSet.Attach(i);
                this._dbContext.Entry(i).State = EntityState.Modified;
            });
            return this._dbContext.SaveChanges() > 0;
        }

        public async Task<bool> UpdateAsync(List<T> entities)
        {
            if (entities == null || entities.Count <= 0)
            {
                return false;
            }
            entities.ForEach(i =>
            {
                this._dbSet.Attach(i);
                this._dbContext.Entry(i).State = EntityState.Modified;
            });
            return await this._dbContext.SaveChangesAsync() > 0;
        }
        #endregion

        #region 删除数据
        public bool Delete(T entity)
        {
            this._dbSet.Attach(entity);
            this._dbSet.Remove(entity);
            return this._dbContext.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            this._dbSet.Attach(entity);
            this._dbSet.Remove(entity);
            return await this._dbContext.SaveChangesAsync() > 0;
        }

        public bool Delete(List<T> entities)
        {
            entities.ForEach(i =>
            {
                this._dbSet.Attach(i);
                this._dbSet.Remove(i);
            });
            return this._dbContext.SaveChanges() > 0;
        }

        public async Task<bool> DeleteAsync(List<T> entities)
        {
            entities.ForEach(i =>
            {
                this._dbSet.Attach(i);
                this._dbSet.Remove(i);
            });
            return await this._dbContext.SaveChangesAsync() > 0;
        }
        #endregion

        #region 查询数据

        public IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda, bool isNoTracking = true)
        {
            var data = this._dbSet.Where(whereLambda);
            return isNoTracking ? data.AsTracking() : data;
        }

        public async Task<IQueryable<T>> GetListAsync(Expression<Func<T, bool>> whereLambda, bool isNoTracking = true)
        {
            return await Task.Run(() => {
                var data = this._dbSet.Where(whereLambda);
                return isNoTracking ? data.AsTracking() : data;
            });
        }

        public int Count(Expression<Func<T, bool>> whereLambda)
        {
            return this._dbSet.Count(whereLambda);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await this._dbSet.CountAsync(whereLambda);
        }

        public T Get(Expression<Func<T, bool>> whereLambda, bool isNoTracking = true)
        {
            return GetList(whereLambda, isNoTracking).FirstOrDefault();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> whereLambda, bool isNoTracking = true)
        {
            var data = GetList(whereLambda, isNoTracking);
            return await data.FirstOrDefaultAsync();
        }

        public T Get(object id)
        {
            return this._dbSet.Find(id);
        }

        public async Task<T> GetAsync(object id)
        {
            return await this._dbSet.FindAsync(id);
        }
        #endregion

        #region 分页查询

        public IQueryable<T> GetPage<TKey>(Expression<Func<T, bool>> whereLambda, int pageIndex, int pageSize, out int totalCount, Expression<Func<T, TKey>> orderBy, bool isAsc = true,
            bool isNoTracking = true)
        {
            var data = GetList(whereLambda, isNoTracking);          
            data =isAsc? data.OrderBy(orderBy):data.OrderByDescending(orderBy);
            totalCount = Count(whereLambda);
            return data.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

   

        public IQueryable<T> GetPage(Expression<Func<T, bool>> whereLambda, int pageIndex, int pageSize, out int totalCount, string orderBy, bool isNoTracking)
        {
            var data = GetList(whereLambda, isNoTracking);
            data = data.OrderByBatch(orderBy);
            totalCount = Count(whereLambda);
            return data.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

     
        #endregion
    }
}
