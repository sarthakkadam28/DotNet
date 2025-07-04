using Catlog;
namespace testerapp
{
    public class Item
    {
        public Product theProduct { get; set; }
        public int Quantity { get; set; }
        public Item(Product product, int quantity)
        {
            theProduct = product;
            Quantity = quantity;
        }
    }
}