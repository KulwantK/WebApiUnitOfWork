using System;
using System.Threading.Tasks;

namespace Atom.Repository.Interface
{
    public interface IUnitOfWork<T>:IDisposable where T:class,IEntity
    {
        IRepository<T> Repository { get; set; }
        Task Commit();
    }
}
