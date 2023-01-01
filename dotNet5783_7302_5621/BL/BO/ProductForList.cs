using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BO
{
    public class ProductForList
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public BO.Enums.category? category { get; set; }
        public override string ToString() => 
            $@"id={ID}
name={Name}
price={Price}
category={category} 
";

    }
}
