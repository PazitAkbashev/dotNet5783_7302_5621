using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Order
    {
        public int ID;
        public string CustomerName;
        public string CustomerEmail;
        public string CustomerAddress;
        public OrderStatus Status;
        public DateTime OrderDate;
        public DateTime PaymentDate;
        public DateTime ShipDate;
        public DateTime DeliveryrDate;
        public OrderItem Items;
        public double TotalPrice;

    }
}
