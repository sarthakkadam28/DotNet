using BillMangement.Entities;
using BillMangement.Repository;
using System.Configuration;

namespace BillMangement.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        public BillService(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<List<Bill>> GetAllBill()
        {
            return await _billRepository.GetAllBill();
        }

       
    }
}
