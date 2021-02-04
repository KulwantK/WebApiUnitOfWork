using Atom.Domain.Entities;

namespace Atom.ApiService.Models
{
    public class AccountDto
    {
        public long AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
