using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Product
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public Enums.category category { get; set; }
        public int InStock { get; set; }

        public override string ToString() => $@"product-id={ID}, product-name={Name},product-price={Price}, Product-category={category}, in-stock={InStock} ";

    }
}
