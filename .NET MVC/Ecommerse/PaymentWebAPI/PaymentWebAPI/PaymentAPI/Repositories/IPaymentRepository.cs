using PaymentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace PaymentApi.Repositories;

public interface IPaymentRepository
{
    public List<Payment>GetAll();
    public Payment? GetById(int id);
    public Payment Add(Payment payment);
  
    public bool Update(Payment payment);
    public bool Delete(int paymentId);
}
