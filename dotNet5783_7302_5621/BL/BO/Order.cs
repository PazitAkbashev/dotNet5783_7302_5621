﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Order
    {
        public int ID;
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime DeliveryrDate { get; set; }
        public OrderItem Items { get; set; }
        public double TotalPrice { get; set; }
        public override string ToString() => $@"customer-id = {ID},customer-name={CustomerName},Mail={CustomerEmail},Adress= {CustomerAddress},order-status= {Status},
Order-date={OrderDate}, Payment-date ={PaymentDate},Ship-date={ShipDate},Deliveryr-date={DeliveryrDate},Order-items={Items},total-price={TotalPrice}";

    }
}
