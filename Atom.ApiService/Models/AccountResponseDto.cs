namespace Atom.ApiService.Models
{
    public class AccountResponseDto
    {
        public long AccountNumber { get; set; }
        public bool Successful { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public string Message { get; set; }
    }
}
