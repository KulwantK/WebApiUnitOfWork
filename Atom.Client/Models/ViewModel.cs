namespace Atom.Client.Models
{
    public class ViewModel
    {
        public long AccountNumber { get; set; }
        public bool Successful { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public string Message { get; set; }
        public double Amount { get; set; }
        public bool ShowBalance { get; set; } = false;
    }
}
