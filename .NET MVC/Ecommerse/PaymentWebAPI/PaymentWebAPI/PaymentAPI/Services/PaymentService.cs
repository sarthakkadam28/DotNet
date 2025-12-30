using PaymentApi.Models;
using PaymentApi.Repositories;

namespace PaymentApi.Services;

public class PaymentService : IPaymentService
{ 
    private readonly IPaymentRepository _repo;
    public PaymentService(IPaymentRepository repo)
    {
        _repo = repo;
    }
    public Payment GetById(int id)
    {
       return _repo.GetById(id); 
    }
     public List<Payment>GetAll()
    {
        return _repo.GetAll();
    }
    public Payment Add(Payment payment)
    {
        return _repo.Add(payment);
    }
    public bool Update(Payment payment)
    {
        return _repo.Update(payment);
    }
   public bool Delete(int paymentId)
    {
      return _repo.Delete(paymentId);  
    }
}