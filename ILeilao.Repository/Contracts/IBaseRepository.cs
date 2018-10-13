using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ILeilao.Repository
{
    public interface IBaseRepository<T> where T : class, new()
    {
        T Add(T model);
        Task<T> AddAsync(T model);
        IEnumerable<T> AddMany(IEnumerable<T> modelList);
        Task<IEnumerable<T>> AddManyAsync(IEnumerable<T> modelList);

        T Find(Expression<Func<T, bool>> filter);
        Task<T> FindAsync(Expression<Func<T, bool>> filter);

        IEnumerable<T> FindAll();
        IEnumerable<T> FindAll(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> filter);

        bool Edit(Expression<Func<T, bool>> filter, T model);
        Task<bool> EditAsync(Expression<Func<T, bool>> filter, T model);

        bool Delete(Expression<Func<T, bool>> filter);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> filter);
    }
}
