using Microsoft.EntityFrameworkCore;
using Atom.Domain.Entities;
using System.Reflection;

namespace Atom.Data
{
    public class AtomDbContext : DbContext
    {
        public AtomDbContext(DbContextOptions<AtomDbContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Seed Data
            modelBuilder.Seed();
        }
    }
}