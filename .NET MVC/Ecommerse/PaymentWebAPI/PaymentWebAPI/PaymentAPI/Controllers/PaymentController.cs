using Microsoft.AspNetCore.Mvc;
using PaymentApi.Services;


namespace ProductWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService paymentService)
        {
            _service = paymentService;
        }

        // POST: api/payment/process
        [HttpPost("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }
    


   
    }
}