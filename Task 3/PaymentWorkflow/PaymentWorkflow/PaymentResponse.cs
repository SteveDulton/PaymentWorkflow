namespace PaymentWorkflow
{
    public class PaymentResponse
    {
        public PaymentStatus Status { get; set; }
        public PaymentRequest PaymentRequest { get; set; } 
        public Guid TransactionId { get; set; }
        public string Message { get; set; }
    }
}