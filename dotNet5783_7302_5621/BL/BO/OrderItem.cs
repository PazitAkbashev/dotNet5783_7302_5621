using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static DO.Enums;

namespace BO
{
    public class OrderItem
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int ProductID { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }

        public override string ToString() => $@"Order-item-id={ID},Order-item-name={ProductName},product-id= {ProductID},
Order-item-price= {Price},amount={Amount}, total-price={TotalPrice}";
    }
}
