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
    public class ProductForList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category category { get; set; }

        public override string ToString() => $@"Product-For-List-id={ID}, name={Name},price={Price}, Product-for-list-category={category} ";

    }
}
