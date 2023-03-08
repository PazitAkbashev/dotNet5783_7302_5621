﻿
namespace DO;
using static DO.Enums;

/// <summary>
/// the product methods
/// Data Object
/// </summary>
public struct Product
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public Category? Category { get; set; }
    public double Price { get; set; }
    public int inStock { get; set; }
    public override string ToString() => $@"Product id={ID},
                                         Product name={Name},
                                         category={Category},
                                         Price= {Price},
                                         Amount in stock= {inStock}";
    //convert this "to strring" into one global function
}
