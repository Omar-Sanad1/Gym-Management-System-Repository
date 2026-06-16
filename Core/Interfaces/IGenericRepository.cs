using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T GetByID(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);

        // Pagination
        public IEnumerable<T> GetAllPaged(int pageNumber , int pageSize);
        public int GetCount();

        // Filtering
        public IEnumerable<T> GetAllFiltered(Func<T, bool> Filter);

    }
}
