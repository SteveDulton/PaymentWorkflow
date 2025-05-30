namespace PaymentWorkflow
{
    public interface IPaymentTransactionService
    {
        PaymentResponse CreateTransaction(PaymentRequest request);
        PaymentResponse ApproveTransaction(Guid transactionId);
        PaymentResponse DeclineTransaction(Guid transactionId);
        PaymentResponse GetTransaction(Guid transactionId);
    }
}
