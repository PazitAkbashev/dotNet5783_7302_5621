using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;
/// <summary>
/// the order interface
/// </summary>
public interface IOrder
{
    public IEnumerable<OrderForList?> getOrderList();
    public Order getOrderDetails(int orderID);
    public Order updateOrderShipping(int orderNumber);
    public Order updateOrderSupply(int orderNumber);
    public OrderTracking getOrderTracking(int orderNumber);
}
