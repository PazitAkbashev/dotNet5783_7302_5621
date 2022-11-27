using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;
/// <summary>
/// 
/// </summary>
public interface IOrder
{
    public IEnumerable<OrderForList> getOrderList();
    public Order getOrderDetails(int);
    public Order updateOrderShipping(int);
    public Order updateOrderSupply(int);
    public OrderTracking getOrderTracking(int);
}
