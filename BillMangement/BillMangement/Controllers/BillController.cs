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
        //http://localhost:5234/api/Bill/DeleteId
        [HttpDelete("DeleteId")]
        public async Task<IActionResult> DeleteById(int BillId)
        {
            // if (BillId <= 0)

            // {
            //     return BadRequest("Invalid bill Id .");
            // }
            //  bool result = await _billService.DeleteById(BillId);
            // if (result)
            // {
            //     return Ok("deleted sucessfully.");
            // }
            // else
            // {
            //     return BadRequest("Invalid Billid");
            // }
            bool result = await _billService.DeleteById(BillId);
            if (result)
            {
                return Ok("deleted sucessfully.");
            }
            else
            {
                return BadRequest("Invalid Billid");
            }


        }
        //http://localhost:5234/api/Bill/UpdateBill
        [HttpPut("UpdateBill")]
        public async Task<IActionResult> UpdateBill(int BillId,Bill billModel)
        {
            if (BillId <= 0 || billModel == null)
            {
                return BadRequest("Invalid input.");
            }

            bool result = await _billService.UpdateBill(BillId, billModel);
            if (result)
            {
                return Ok("Bill updated successfully.");
            }
            else
            {
                return NotFound("Bill not found.");
            }
        }
    
    }
}
