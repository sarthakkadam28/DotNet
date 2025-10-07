using BillMangement.Entities;

namespace BillMangement.Repository
{
    public interface IBillRepository
    {


        Task<List<Bill>> GetAllBill();
        Task<bool> AddBill(BillModel billModel);
        Task<List<BillDetail>> GetBillDetail();
        Task<bool> DeleteById(int BillId);
        Task<bool> UpdateBill(int BillId,Bill billModel);

    }
}
