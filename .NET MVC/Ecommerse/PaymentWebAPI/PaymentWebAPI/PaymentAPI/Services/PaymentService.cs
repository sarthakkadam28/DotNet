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
        
    }
}