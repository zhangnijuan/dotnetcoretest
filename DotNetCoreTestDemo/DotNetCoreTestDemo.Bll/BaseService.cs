using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DotNetCoreTestDemo.IBll;
using DotNetCoreTestDemo.IDal;
using DotNetCoreTestDemo.Model;

namespace DotNetCoreTestDemo.Bll
{
    public class BaseService<T>:IBaseService<T>  where T:class 
    {
        protected  IBaseDal<T> BaseDal;
     
        public bool Insert(T entity)
        {
            return this.BaseDal.Insert(entity);
        }

        public bool Insert(List<T> entities)
        {
            return this.BaseDal.Insert(entities);
        }

        public async Task<bool> InsertAsync(T entity)
        {
            return await this.BaseDal.InsertAsync(entity);
        }

        public async Task<bool> InsertAsync(List<T> entities)
        {
            return await this.BaseDal.InsertAsync(entities);
        }

        public bool Update(T entity, List<string> updatePropertyList = null, bool modified = true)
        {
            return this.BaseDal.Update(entity, updatePropertyList, modified);
        }

        public async Task<bool> UpdateAsync(T entity, List<string> updatePropertyList = null, bool modified = true)
        {
            return await this.BaseDal.UpdateAsync(entity, updatePropertyList, modified);
        }

        public bool Update(List<T> entities)
        {
            return this.BaseDal.Update(entities);
        }

        public async Task<bool> UpdateAsync(List<T> entities)
        {
            return await this.BaseDal.UpdateAsync(entities);
        }

        public bool Delete(T entity)
        {
            return this.BaseDal.Delete(entity);
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            return await this.BaseDal.DeleteAsync(entity);
        }

        public bool Delete(List<T> entities)
        {
            return this.BaseDal.Delete(entities);
        }

        public async Task<bool> DeleteAsync(List<T> entities)
        {
            return await this.BaseDal.DeleteAsync(entities);
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda, bool isNoTracking = true)
        {
            return this.BaseDal.GetList(whereLambda, isNoTracking);
        }

        public async Task<IQueryable<T>> GetListAsync(Expression<Func<T, bool>> whereLambda, bool isNoTracking = true)
        {
            return await this.BaseDal.GetListAsync(whereLambda, isNoTracking);
        }

        public int Count(Expression<Func<T, bool>> whereLambda)
        {
            return this.BaseDal.Count(whereLambda);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await this.BaseDal.CountAsync(whereLambda);
        }

        public T Get(Expression<Func<T, bool>> whereLambda, bool isNoTracking = true)
        {
            return this.BaseDal.Get(whereLambda, isNoTracking);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> whereLambda, bool isNoTracking = true)
        {
            return await this.BaseDal.GetAsync(whereLambda, isNoTracking);
        }

        public T Get(object id)
        {
            return this.BaseDal.Get(id);
        }

        public async Task<T> GetAsync(object id)
        {
            return await this.BaseDal.GetAsync(id);
        }

        public IQueryable<T> GetPage<TKey>(Expression<Func<T, bool>> whereLambda, int pageIndex, int pageSize, out int totalCount, Expression<Func<T, TKey>> orderBy,
            bool isAsc = true, bool isNoTracking = true)
        {
            return this.BaseDal.GetPage(whereLambda, pageIndex, pageSize, out totalCount, orderBy, isAsc,
                isNoTracking);
        }

        public IQueryable<T> GetPage(Expression<Func<T, bool>> whereLambda, int pageIndex, int pageSize, out int totalCount, string orderBy,
            bool isNoTracking)
        {
            return this.BaseDal.GetPage(whereLambda, pageIndex, pageSize, out totalCount, orderBy, isNoTracking);
        }
    }
}
