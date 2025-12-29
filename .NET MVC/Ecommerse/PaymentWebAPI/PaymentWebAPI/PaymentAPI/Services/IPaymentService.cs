using PaymentApi.Models;

namespace PaymentApi.Services;

public interface IPaymentService
{
    Payment GetById(int id);
    
}