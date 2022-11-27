﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DO.Enums;

namespace BO
{
    public class Cart
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public OrderItem Items { get; set; }
        public double TotalPrice { get; set; }
        public override string ToString() => $@"customer-name={CustomerName},Mail={CustomerEmail},Adress= {CustomerAddress},
Cart-items= {Items},total-price={TotalPrice}";
    }
}