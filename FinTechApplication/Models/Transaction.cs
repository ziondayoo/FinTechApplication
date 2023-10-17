namespace FinTechApplication.Models
{
    public class Transaction
    {
        public AppUser User { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Transfer
    }
}
