using OrderSummary.Entities;
using OrderSummary.Entities.Enum;
using System.Globalization;

namespace OrderSummary
{
    class Program
    {
       
        Order order = new Order();
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(name, email, date);
            Order order = new Order(date, status, client);

            Console.Write("How many items to this order? ");
            int QtdOrder = int.Parse(Console.ReadLine());

            for (int i = 1; i <=QtdOrder; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string nameProduct = Console.ReadLine();
                Console.Write("Product price: ");
                double priceProduct = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

                Product product = new Product(nameProduct, priceProduct);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                
              OrderIntem orderItem = new OrderIntem(quantity, priceProduct, product);  

                order.addIntem(orderItem);
            }
            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);
        }
    }
}