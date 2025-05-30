public class PaymentRequest
{
    public string CardNumber { get; set; }
    public string ExpirationDate { get; set; }
    public string CVV { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
}