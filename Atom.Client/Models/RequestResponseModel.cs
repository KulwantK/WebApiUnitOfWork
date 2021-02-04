namespace Atom.Client.Models
{
    public class RequestResponseModel
    {
        public long AccountNumber { get; set; }
        public bool Successful { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public string Message { get; set; }
        public decimal Amount { get; set; }
    }
}
