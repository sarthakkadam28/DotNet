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
        public async Task<bool> AddBill(BillModel billModel)
        {
            return await _billRepository.AddBill(billModel);
        }
        public async Task<List<BillDetail>> GetBillDetail()
        {
            return await _billRepository.GetBillDetail();
        }
        public async Task<List<int>> DeleteById(int BillId)
        {
            return await _billRepository.DeleteById(BillId);
        }
    }
}
