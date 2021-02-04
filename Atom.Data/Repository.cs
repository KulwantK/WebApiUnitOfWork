using Atom.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Atom.Data
{
    public class Repository<T> : IRepository<T> where T:class,IEntity
    {
        public DbSet<T> Table{ get; set; }
        public Repository(AtomDbContext atomDbContext)
        {
            Table = atomDbContext.Set<T>();
        }
        public async Task Add(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task Add(IEnumerable<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public async Task<IList<T>> All()
        {
           return await Table.AsNoTracking().ToListAsync();
        }
        public async Task<T> GetById(long id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = Table;
            query = query.Where(expression);/*.AsNoTracking();*/

            return await query.ToListAsync().ConfigureAwait(false);
        }
        public void Update(T entity)
        {
            try
            {
                Table.Update(entity);
            }
            catch(DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
