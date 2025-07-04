using testerapp;
using 

namespace ShoppingCart
{
    public class Cart
    {
        private List<Item> items = new List<Item>();

        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }
        public void AddToCart(Item item)
        {
            items.Add(item);
        }
        public void RemoveFromCart(Item item)
        {
            items.Remove(item);
        }
    }
}