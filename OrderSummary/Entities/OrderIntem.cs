using System.Globalization;

namespace OrderSummary.Entities
{
    public class OrderIntem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; } = new Product();

        public OrderIntem() { }

        public OrderIntem(int quantity, double price, Product product)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
        }

        public double SubTotal()
        {
            return Quantity * Price;
        }
        public override string ToString()
        {
            return Product.Name+", $"+Price.ToString("F2",CultureInfo.InvariantCulture)+", Quantity: "+Quantity+", Subtotal: $"+SubTotal().ToString("F2",CultureInfo.InvariantCulture);    
        }
    }
}
