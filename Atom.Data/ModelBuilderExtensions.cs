using Atom.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Atom.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(new List<Account>()
            {
               new Account{Id=1,Balance = 500,CreationDate = DateTime.Now,Currency = "$"}
               ,new Account{Id=2,Balance = 1500,CreationDate = DateTime.Now,Currency = "$"}
               ,new Account{Id=3,Balance = 100,CreationDate = DateTime.Now,Currency = "$"}
               ,new Account{Id=4,Balance = 45,CreationDate = DateTime.Now,Currency = "$"}
               ,new Account{Id=5,Balance = 50,CreationDate = DateTime.Now,Currency = "$"}
               ,new Account{Id=7,Balance = 900,CreationDate = DateTime.Now,Currency = "$"}
               ,new Account{Id=8,Balance = 90,CreationDate = DateTime.Now,Currency = "$"}
               ,new Account{Id=9,Balance = 19,CreationDate = DateTime.Now,Currency = "$"}
               ,new Account{Id=10,Balance = 190,CreationDate = DateTime.Now,Currency = "$"}
            });
        }
    }
}
