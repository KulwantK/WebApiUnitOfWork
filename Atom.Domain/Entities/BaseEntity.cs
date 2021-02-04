using Atom.Repository.Interface;
using System;
using System.ComponentModel.DataAnnotations;

namespace Atom.Domain.Entities
{
    public class BaseEntity : IEntity
    {
        public BaseEntity()
        {
            Id = 0;
        }
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
