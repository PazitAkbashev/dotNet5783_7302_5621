using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BO;
using DalApi;
//using DalApi;

namespace BlImplementation;

internal class Order : BlApi.IOrder
{
    private DalApi.IDal dalOrder = new Dal.DalList();

    public IEnumerable<BO.OrderForList> getOrderList()
    {
        
    }
    public Order getOrderDetails(int orderID)
    {

    }
    public Order updateOrderShipping(int orderNumber)
    {

    }
    public Order updateOrderSupply(int orderNumber)
    {

    }
    public OrderTracking getOrderTracking(int orderNumber)
    {

    }
}
