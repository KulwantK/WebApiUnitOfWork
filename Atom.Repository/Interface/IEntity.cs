using System;
using System.ComponentModel.DataAnnotations;

namespace Atom.Repository.Interface
{
    public interface IEntity
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
