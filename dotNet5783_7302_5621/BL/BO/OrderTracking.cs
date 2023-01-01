using DO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static BO.Enums;
namespace BO
{
    /// <summary>
    /// the order tracking methods
    /// </summary>
    public class OrderTracking
    {
        public int ID { get; set; }
        public orderStatus? Status { get; set; }
        public List<Tuple<DateTime?, string?>>? myList { get; set; }
        public override string ToString() => $@"Order-tracking-id={ID},status={Status}";
    }

}
