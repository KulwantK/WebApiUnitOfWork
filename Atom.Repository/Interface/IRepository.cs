using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Atom.Repository.Interface
{
    public interface IRepository<T> where T:class,IEntity
    {
        Task Add(T entity);
        Task Add(IEnumerable<T> entities);
        Task<IList<T>> All();
        Task<T> GetById(long id);
        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> expression);
        void Update(T entity);
    }
}
