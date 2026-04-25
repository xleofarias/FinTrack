namespace FinTrack.API.Contracts
{
    public class UpdateTransactionAmountRequest
    {
        public decimal Amount { get; set; }
        public required string Currency { get; set; }
    }
}
