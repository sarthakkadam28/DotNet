namespace PaymentApi.Models;

public class PaymentResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
    public int PaymentId { get; set; }
}
