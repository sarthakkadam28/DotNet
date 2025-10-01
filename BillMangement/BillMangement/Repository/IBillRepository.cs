using BillMangement.Entities;

namespace BillMangement.Repository
{
    public interface IBillRepository
    {
       

        Task<List<Bill>> GetAllBill();
 

    }
}
