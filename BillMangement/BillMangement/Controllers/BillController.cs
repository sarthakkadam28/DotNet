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
        //http://localhost:5234/api/Bill/bill
        [HttpPost("add")]
        public async Task<IActionResult> AddBill(BillModel billModel)
        {
            var result = await _billService.AddBill(billModel);
            if (result == null)
            {
                return StatusCode(500, "not added successfully");
            }
            return Ok(result);
        }
        //http://localhost:5234/api/Bill/GetDetails
        [HttpGet("GetDetails")]
        public async Task<IActionResult> GetBillDetail()
        {
            List<BillDetail> details = await _billService.GetBillDetail();
            if (details == null || details.Count == 0)
            {
                return NotFound("no bill found");
            }
            return Ok(details);


        }
        [HttpDelete("DeleteId")]
        public async Task<IActionResult> DeleteById(int BillId)
        {
            if (BillId <= 0)
            {
                return BadRequest("Invalid subject Id .");
            }
            int result = await _billService.DeleteById(BillId);
            if (result > 0)
            {
                return Ok("deleted sucessfully.");
            }
            if (result == 0)
            {
                return BadRequest("Invalid Billid");
            }
            return StatusCode(500, "error occurred while deleting the deatils");

        }
    
    }
}
