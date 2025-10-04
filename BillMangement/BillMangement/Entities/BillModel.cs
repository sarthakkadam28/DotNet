namespace BillMangement.Entities
{
    public class BillModel
    {
                 
        public string CustomerName { get; set; }            
        public DateTime BillDate { get; set; }              
        public decimal TotalAmount { get; set; }             
        public decimal TaxAmount { get; set; }                
        public decimal NetAmount { get; set; }            
        public string PaymentMethod { get; set; }

    }
}