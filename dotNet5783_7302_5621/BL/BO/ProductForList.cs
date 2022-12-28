using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DO.Enums;
namespace BO
{
    /// <summary>
    /// the product for list methods
    /// </summary>
    public class ProductForList
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public Category? category { get; set; }
        public override string ToString() => 
            $@"id={ID}
name={Name}
price={Price}
category={category} 
";

    }
}
