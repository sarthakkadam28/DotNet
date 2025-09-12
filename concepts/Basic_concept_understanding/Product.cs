using System;
namespace Catlog
{
    public class Product
    {
        private string title;
        private string description;
        private int quantity;
        private float price;
        private int id;
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
        public int Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }
        public float Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public Product()
        {

        }
        public Product(int id, string title, string description, int quantity, float price)
        {
            this.id = 0;
            this.title = title;
            this.description = description;
            this.quantity = quantity;
            this.price = price;
        }
        ~Product()
        {

        }
        public override string ToString()
        {
            return $"Product [Id={id}, Title={title}, Description={description}, Quantity={quantity}, Price={price}]";
        }
    }
}