using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ILeilao.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly ILeilaoContext _context;
        protected IMongoCollection<T> Collection { get; set; }

        #region Constructors

        public BaseRepository(ILeilaoContext context)
        {
            _context = context;
        }

        public BaseRepository(ILeilaoContext context, string collectionName)
            : this(context)
        {
            Collection = _context.Collection<T>(collectionName);
        }

        #endregion

        #region Methods

        #region Add

        public T Add(T model)
        {
            Collection.InsertOne(model);
            return model;
        }

        public Task<T> AddAsync(T model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> AddMany(IEnumerable<T> modelList)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> AddManyAsync(IEnumerable<T> modelList)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Find

        public T Find(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<Task<T>> FindAsync(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Edit

        public bool Edit(Expression<Func<T, bool>> filter, T model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(Expression<Func<T, bool>> filter, T model)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Delete

        public bool Delete(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion
    }
}
