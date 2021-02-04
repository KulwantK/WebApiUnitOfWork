namespace Atom.Domain.Entities
{
    public class Account : BaseEntity
    {
        public Account()
        {
            
        }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
    }
}
