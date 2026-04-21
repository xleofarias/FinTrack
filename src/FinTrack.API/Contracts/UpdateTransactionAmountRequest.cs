namespace FinTrack.API.Contracts
{
    public class UpdateTransactionAmountRequest
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
