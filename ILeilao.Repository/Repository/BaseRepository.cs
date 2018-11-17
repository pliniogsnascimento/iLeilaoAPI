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

        public async Task<T> AddAsync(T model)
        {
            await Collection.InsertOneAsync(model);
            return model;
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

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> filter)
        {
            var model = await Collection.FindAsync(filter);
            return await model.AnyAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> filter)
        {
            if(await ExistsAsync(filter))
            {
                var model = await Collection.FindAsync(filter);
                return model.First();
            }

            return null;
        }

        public IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> filter)
        {

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await Collection.AsQueryable()
                .ToListAsync();
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

        public async Task<bool> EditAsync(Expression<Func<T, bool>> filter, T model)
        {
            ReplaceOneResult result =
                await Collection
                .ReplaceOneAsync(filter, model);
            return result
                .ModifiedCount > 0;
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
