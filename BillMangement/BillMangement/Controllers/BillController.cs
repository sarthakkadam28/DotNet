using Microsoft.AspNetCore.Mvc;
using BillMangement.Entities;
using BillMangement.Services;


namespace BillMangement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;
        public BillController(IBillService billService)
        {
            _billService = billService;
        }
        //http://localhost:5264/api/bill/bills
        [HttpGet("Bills")]
        public async Task<IActionResult> GetAllBill()
        {
            List<Bill>bills = await _billService.GetAllBill();
            if(bills==null || bills.Count == 0)
            { 
                return NotFound ("no bill found");
            }
            return Ok(bills);
        }
    }
}
