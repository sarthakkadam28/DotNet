using Microsoft.AspNetCore.Mvc;
using BillMangement.Entities;
using BillMangement.Services;


namespace BillMangement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;
        public BillController(IBillService billService)
        {
            _billService = billService;
        }
        //http://localhost:5264/api/Bill/bills
        [HttpGet("bills")]
        public async Task<IActionResult> GetAllBill()
        {
            List<Bill> bills = await _billService.GetAllBill();
            if (bills == null || bills.Count == 0)
            {
                return NotFound("no bill found");
            }
            return Ok(bills);
        }
        //http://localhost:5234/api/Bill/result
        [HttpPost("bill")]
        public async Task<IActionResult> AddBill([FromBody]Bill bill)
        {
            var result = await _billService.AddBill(bill);
            if (result ==null)
            {
               return StatusCode(500,"not added successfully");
            }
            return Ok(result);
            
        }
    }
}
