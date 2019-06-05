using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DotNetCoreTestDemo.Model;

namespace DotNetCoreTestDemo.IBll
{
    public interface IBaseService<T> where T:class 
    {
        #region 插入数据
        bool Insert(T entity);
        bool Insert(List<T> entities);
        Task<bool> InsertAsync(T entity);
        Task<bool> InsertAsync(List<T> entities);
        #endregion

        #region 更新数据
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="updatePropertyList">部分字段</param>
        /// <param name="modified">部分字段是否更新</param>
        /// <returns></returns>
        bool Update(T entity, List<string> updatePropertyList = null, bool modified = true);
        Task<bool> UpdateAsync(T entity, List<string> updatePropertyList = null, bool modified = true);
        bool Update(List<T> entities);
        Task<bool> UpdateAsync(List<T> entities);
        #endregion


        #region 删除数据
        bool Delete(T entity);
        Task<bool> DeleteAsync(T entity);
        bool Delete(List<T> entities);
        Task<bool> DeleteAsync(List<T> entities);
        #endregion

        #region 查询
        IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda, bool isNoTracking = true);
        Task<IQueryable<T>> GetListAsync(Expression<Func<T, bool>> whereLambda, bool isNoTracking = true);

        int Count(Expression<Func<T, bool>> whereLambda);
        Task<int> CountAsync(Expression<Func<T, bool>> whereLambda);

        T Get(Expression<Func<T, bool>> whereLambda, bool isNoTracking = true);
        Task<T> GetAsync(Expression<Func<T, bool>> whereLambda, bool isNoTracking = true);
        T Get(object id);
        Task<T> GetAsync(object id);
        #endregion


        #region 分页查询
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        IQueryable<T> GetPage<TKey>(Expression<Func<T, bool>> whereLambda, int pageIndex, int pageSize, out int totalCount,
            Expression<Func<T, TKey>> orderBy, bool isAsc = true, bool isNoTracking = true);
        //Task<IQueryable<T>> GetPageAsync<TKey>(Expression<Func<T, bool>> whereLambda, int pageIndex, int pageSize, out int totalCount,
        //    Expression<Func<T, TKey>> orderBy, bool isAsc = true, bool isNoTracking = true);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy">>排序条件（一定要有，多个用逗号隔开，倒序开头用-号）</param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        IQueryable<T> GetPage(Expression<Func<T, bool>> whereLambda, int pageIndex, int pageSize, out int totalCount, string orderBy,
            bool isNoTracking);
        //Task<IQueryable<T>> GetPageAsync(Expression<Func<T, bool>> whereLambda, int pageIndex, int pageSize, out int totalCount, string orderBy,
        //    bool isNoTracking);
        #endregion
    }
}
