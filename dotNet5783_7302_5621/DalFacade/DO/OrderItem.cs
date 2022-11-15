﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using System.Xml.Linq;
using static DO.Enums;

namespace DO; //parit
/// <summary>
/// 
/// </summary>
public struct OrderItem
{
    public int ID { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }
    public override string ToString() => $@"Item unique-id={ID}, Item Order-id={OrderId},Product-id={ProductId},Price= {Price},Amount in stock= {Amount}";

}