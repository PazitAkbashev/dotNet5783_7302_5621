using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DO.Enums;
namespace BO
{
    /// <summary>
    /// the product item methods
    ///  Business Object
    /// </summary>
    public class ProductItem
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public Category category { get; set; }
        public int Amount { get; set; }
        public bool InStock { get; set; }

        public override string ToString() => $@"Product-item-id={ID}, name={Name},price={Price}, product-item-category={category}, amount={Amount},in-stock={InStock}  ";

    }
}
