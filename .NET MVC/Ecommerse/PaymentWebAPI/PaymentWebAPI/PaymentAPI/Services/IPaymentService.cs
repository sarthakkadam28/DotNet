using PaymentApi.Models;

namespace PaymentApi.Services;

public interface IPaymentService
{
    public Payment GetById(int id);
   public List<Payment>GetAll();
    public Payment Add(Payment payment);
    public bool Update(Payment payment);
    public bool Delete(int paymentId);
    
}