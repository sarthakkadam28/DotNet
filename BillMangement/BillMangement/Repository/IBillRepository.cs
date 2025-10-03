using BillMangement.Entities;

namespace BillMangement.Repository
{
    public interface IBillRepository
    {
       

        Task<List<Bill>> GetAllBill();
         Task<Bill> AddBill(Bill bill);

    }
}
