using Microsoft.Extensions.Primitives;
using OrderSummary.Entities.Enum;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace OrderSummary.Entities
{
    public class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; } 
        public List<OrderIntem> Items { get; set; } = new List<OrderIntem>();
        
        

        public Order() { }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = DateTime.Now;
            Status = status;
            Client = client;
        }

        public void addIntem(OrderIntem item) 
        {
          Items.Add(item);
        }
        public void removeIntem(OrderIntem item)
        {
            Items.Remove(item);
        }
        public double Total()
        {
            double sum = 0;
            foreach(OrderIntem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }
        public override string ToString()
        {
           StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY: ");
            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH/mm/ss"));
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Order intems");
            foreach (OrderIntem item in Items)
            {
              sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Total price: " + Total().ToString("F2",CultureInfo.InvariantCulture));
            return sb.ToString();

        }

    }
}
