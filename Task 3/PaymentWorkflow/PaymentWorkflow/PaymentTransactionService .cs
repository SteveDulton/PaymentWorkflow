namespace PaymentWorkflow
{
    public class PaymentTransactionService : IPaymentTransactionService
    {
        private readonly Dictionary<Guid, PaymentResponse> _transactions = new Dictionary<Guid, PaymentResponse>();

        public PaymentResponse CreateTransaction(PaymentRequest request)
        {
            var transaction = new PaymentResponse
            {
                TransactionId = Guid.NewGuid(),
                PaymentRequest = request,
                Status = PaymentStatus.Pending,
                Message = "Transaction created. Awaiting manual approval."
            };

            _transactions[transaction.TransactionId] = transaction;
            return transaction;
        }

        public PaymentResponse ApproveTransaction(Guid transactionId)
        {
            if (_transactions.TryGetValue(transactionId, out var transaction))
            {
                transaction.Status = PaymentStatus.Approved;
                transaction.Message = "Transaction approved manually.";
                return transaction;
            }
            throw new Exception("Transaction not found.");
        }

        public PaymentResponse DeclineTransaction(Guid transactionId)
        {
            if (_transactions.TryGetValue(transactionId, out var transaction))
            {
                transaction.Status = PaymentStatus.Declined;
                transaction.Message = "Transaction declined manually";
                return transaction;
            }
            throw new Exception("Transaction not found.");
        }

        public PaymentResponse GetTransaction(Guid transactionId)
        {
            if (_transactions.TryGetValue(transactionId, out var transaction))
            {
                return transaction;
            }
            throw new Exception("Transaction not found.");
        }
    }
}
