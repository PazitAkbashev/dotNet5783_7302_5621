using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DO.Enums;
using static BO.Enums;
namespace BO
{
    public class OrderForList
    {
        public int ID { get; set; }
        public string? CustomerName { get; set; }
        public orderStatus? Status { get; set; }
        public int AmountOfItems { get; set; }
        public double TotalPrice { get; set; }
        public override string ToString() => $@"customer-id={ID},customer-name={CustomerName},status= {Status},
amount-of-items= {AmountOfItems},total-price={TotalPrice}";
    }
}
