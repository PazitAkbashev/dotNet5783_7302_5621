using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DO.Enums;


namespace BO
{
    public class ProductItem
    {
        public int ID;
        public string Name;
        public double Price;
        public Caterory caterory;
        public int Amount;
        public bool InStock;
    }
}
