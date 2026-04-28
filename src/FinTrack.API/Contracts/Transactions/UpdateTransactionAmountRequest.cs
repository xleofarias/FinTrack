namespace FinTrack.API.Contracts.Transactions
{
    public class UpdateTransactionAmountRequest
    {
        public decimal Amount { get; set; }
        public required string Currency { get; set; }
    }
}
