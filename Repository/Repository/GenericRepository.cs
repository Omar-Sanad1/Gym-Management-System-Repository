using Core.Interfaces;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly GymManagementSystemDbContext _dbContext;
        public GenericRepository(GymManagementSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        => _dbContext.Set<T>().ToList();

        public T GetByID(int id)
        => _dbContext.Set<T>().Find(id);

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }

        // Pagination

        public IEnumerable<T> GetAllPaged(int pageNumber , int pageSize)
        {
            return _dbContext.Set<T>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        }

        public int GetCount()
        {
            return _dbContext.Set<T>().Count();
        }

        // Filtering

        public IEnumerable<T> GetAllFiltered(Func<T , bool> Filter)
        {
            return _dbContext.Set<T>()
                   .Where(Filter)
                   .ToList();
        }
    }
}
