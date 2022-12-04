using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
//using DalApi;

namespace BlImplementation;

internal class Order :BlApi.IOrder
{
    private DalApi.IDal dalOrder = new Dal.DalList();

    public IEnumerable<BO.OrderForList> getOrderList()
    {
        IEnumerable<DO.Order> tempOrderList = dalOrder.Order.GetAll();
        List<BO.OrderForList> tempOrderForList=new List<BO.OrderForList>();
        foreach(var item in tempOrderList)
        {
            BO.OrderForList tempOrder =new BO.OrderForList();
            tempOrder.ID = item.ID;
            tempOrder.CustomerName = item.CustomerName;
            tempOrder.AmountOfItems =;
            tempOrder.status =;
            tempOrder.AmountOfItems =;
            tempOrder.TotalPrice =;
            tempOrderForList.Add(tempOrder);
        }
        return tempOrderForList;
    }
    public BO.Order getOrderDetails(int orderID)
    {
        BO.Order tempOrder2 = new BO.Order();
        if (orderID>0)
        {
            DO.Order tempOrder=dalOrder.Order.Get(orderID);
            DO.OrderItem tempOrderItem = dalOrder.OrderItem.Get(orderID);
            tempOrder2.ID = tempOrder.ID;
            tempOrder2.CustomerName=tempOrder.CustomerName;
            tempOrder2.CustomerAddress = tempOrder.CustomerAdress;
            tempOrder2.CustomerEmail=tempOrder.CustomerEmail;
            tempOrder2.OrderDate=tempOrder.OrderDate;
            tempOrder2.ShipDate=tempOrder.ShipDate;
            tempOrder2.DeliveryrDate=tempOrder.DeliveryrDate;
            tempOrder2.PaymentDate =;
            tempOrder2.Status =;
            tempOrder2.Items =;
            tempOrder2.TotalPrice =;
        }
        else
        {
            throw new BO.MyException("");
        }
        return tempOrder2;
    }
    public Order updateOrderShipping(int orderNumber)
    {




    }
    public Order updateOrderSupply(int orderNumber)
    {

    }
    public BO.OrderTracking getOrderTracking(int orderNumber)
    {

    }
}
