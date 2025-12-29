using System.Text.Json;
using PaymentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using ShipmentAPI.Helpers;

namespace PaymentApi.Repositories;

public class PaymentRepository : IPaymentRepository
{
  private static readonly string filePath = "Data/Payments.json";
  public Payment? GetById(int id)
  {
    //  List<Payment> payments= GetAll();
    //  return payments.FirstOrDefault(p => p.Id == id);
    var pay = JsonHelper.LoadJson<List<Payment>>(filePath);
    foreach (var payment in pay)
    {
      if (payment.Id == id)
      {
        return payment;
      }
    }
    return null;
  }
  public List<Payment> GetAll()
  {
    return JsonHelper.LoadJson<List<Cart>>(filePath);
  }
  public Payment Add(Payment payment)
  {
    var pay = JsonHelper.LoadJson<List<Payment>>(filePath);
    for (int i = 0; i < pay.Count; i++)
    {
      if (pay[i].Id == payment.Id)
      {
        pay[i] = payment;
        JsonHelper.SaveJson(filePath, pay);
        break;
      }
    }
  }
    public bool Update(Payment payment)
   {
    var payments = JsonHelper.LoadJson<List<Payment>>(filePath);

    if (payments == null || payments.Count == 0)
      return false;

    for (int i = 0; i < payments.Count; i++)
    {
      if (payments[i].Id == payment.Id)
      {
        payments[i] = payment;
        JsonHelper.SaveJson(filePath, payments);
        return true;
      }
    }

    return false;
  }
  public bool Delete(int paymentId)
  {
    var payments = JsonHelper.LoadJson<List<Payment>>(filePath);

    if (payments == null || payments.Count == 0)
        return false;

    var paymentToDelete = payments.FirstOrDefault(p => p.Id == paymentId);

    if (paymentToDelete == null)
        return false; 

    payments.Remove(paymentToDelete);  
    JsonHelper.SaveJson(filePath, payments);

    return true; 
  }
 
}

