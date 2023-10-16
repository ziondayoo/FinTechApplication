namespace FinTechApplication.Models
{
    public class Account
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? AccountNumber { get; set; }
        public AccountType AccountType { get; set; }

        public decimal AccountBalance { get; set; }
        public AppUser? User { get; set; }
    }

    public enum AccountType
    {
        Checking,
        Savings,
        Investment
    }

}
