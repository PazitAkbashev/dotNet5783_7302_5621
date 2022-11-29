using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DO.Enums;

namespace BO
{
    public class OrderForList
    {
        public int ID { get; set; }
        public string ?CustomerName { get; set; }
        public OrderStatus status { get; set; }
        public int AmountOfItems { get; set; }
        public double TotalPrice { get; set; }

        public override string ToString() => $@"customer-id={ID},customer-name={CustomerName},status= {status},
amount-of-items= {AmountOfItems},total-price={TotalPrice}";
    }
}
