using Atom.Repository.Interface;
using System.Threading.Tasks;

namespace Atom.Data
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class, IEntity
    {
        public IRepository<T> Repository { get; set; }
        private readonly AtomDbContext atomDbContext;

        public UnitOfWork(AtomDbContext atomDbContext)
        {
            this.atomDbContext = atomDbContext;
            Repository = new Repository<T>(atomDbContext);
        }
        public async Task Commit()
        {
            await atomDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            atomDbContext.Dispose();
        }
    }
}
