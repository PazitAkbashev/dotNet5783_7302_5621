using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DO.Enums;
namespace BO

{
    /// <summary>
    /// the cart methods
    /// Business Object
    /// </summary>
    public class Cart
    {
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerAddress { get; set; }
        public List<BO.OrderItem> ?Items { get; set; }
        public double TotalPrice { get; set; }
        public override string ToString() => $@"customer-name={CustomerName},Mail={CustomerEmail},Adress= {CustomerAddress},
        Cart-items= {Items},total-price={TotalPrice}";
    }
}
