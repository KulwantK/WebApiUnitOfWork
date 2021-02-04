using Atom.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
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
            try
            {
                await atomDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex) 
            {

                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is T)
                    {
                        var proposedValues = entry.CurrentValues;
                        var databaseValues = entry.GetDatabaseValues();
                        if(databaseValues==null)
                        {
                            throw new Exception("invalid account");
                        }
                        foreach (var property in proposedValues.Properties)
                        {
                            var proposedValue = proposedValues[property];
                            var databaseValue = databaseValues[property];

                            // TODO: decide which value should be written to database
                            // proposedValues[property] = <value to be saved>;
                        }

                        // Refresh original values to bypass next concurrency check
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                    else
                    {
                        throw new NotSupportedException(
                            "unhandled exception "
                            + entry.Metadata.Name);
                    }
                }
            }
        }
        public void Dispose()
        {
            atomDbContext.Dispose();
        }
    }
}
