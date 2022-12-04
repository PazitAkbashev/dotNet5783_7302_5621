using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BO;
//using DalApi;

namespace BlImplementation;

internal class Order :BlApi.IOrder
{
    private DalApi.IDal dalOrder = new Dal.DalList();

    public IEnumerable<BO.OrderForList> getOrderList()
    {
        IEnumerable<DO.Order> tempOrderList = dalOrder.Order.GetAll();
        List<BO.OrderForList> tempOrderForList=new List<BO.OrderForList>();
        foreach (var item in tempOrderList)
        {
            BO.OrderForList tempOrder =new BO.OrderForList();
            BO.Order tempOrder2 = getOrderDetails(item.ID);
            tempOrder.ID = tempOrder2.ID;
            tempOrder.CustomerName = tempOrder2.CustomerName;
            tempOrder.AmountOfItems = tempOrder2.Items.Count;
            tempOrder.Status = tempOrder2.Status;
            tempOrder.TotalPrice = tempOrder2.TotalPrice;
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
            IEnumerable <DO.OrderItem> orderItems = dalOrder.OrderItem.GetAll();
            tempOrder2.ID = tempOrder.ID;
            tempOrder2.CustomerName=tempOrder.CustomerName;
            tempOrder2.CustomerAddress = tempOrder.CustomerAdress;
            tempOrder2.CustomerEmail=tempOrder.CustomerEmail;
            tempOrder2.OrderDate=tempOrder.OrderDate;
            tempOrder2.ShipDate=tempOrder.ShipDate;
            tempOrder2.DeliveryrDate=tempOrder.DeliveryrDate;
            if(tempOrder2.OrderDate>DateTime.Now&& tempOrder2.ShipDate < DateTime.Now)
                tempOrder2.Status = BO.Enums.orderStatus.Confirmed;
            if(tempOrder2.ShipDate > DateTime.Now&& tempOrder2.DeliveryrDate < DateTime.Now)
                tempOrder2.Status = BO.Enums.orderStatus.Shipped;
            if(tempOrder2.DeliveryrDate> DateTime.Now)
                tempOrder2.Status = BO.Enums.orderStatus.Supplied;
            double myTotalPrice = 0;
            foreach(var item in orderItems)
            {
                if(item.OrderId== orderID)
                {
                    myTotalPrice += item.Price;
                    BO.OrderItem myOrder=new BO.OrderItem();
                    myOrder.ID = item.ID;
                    DO.Product tempProduct= dalOrder.Product.Get(item.ProductId);
                    myOrder.ProductName = tempProduct.Name;
                    myOrder.ProductID = item.ProductId;
                    myOrder.Price=item.Price;
                    myOrder.Amount = item.Amount;
                    myOrder.TotalPrice =item.Price*item.Amount;
                    tempOrder2.Items.Add(myOrder);
                }
            }
            tempOrder2.TotalPrice = myTotalPrice;
            return tempOrder2;
        }
        else
        {
            throw new BO.MyException("");
        }
    }
    public BO.Order updateOrderShipping(int orderNumber)
    {
        IEnumerable<DO.Order> orders = dalOrder.Order.GetAll();
        foreach(var item in orders)
        {
            if(item.ID== orderNumber&&item.ShipDate< DateTime.Now)
            {
                DO.Order order=item;
                order.ShipDate = DateTime.Now;
                BO.Order order2=new BO.Order();
                order2.ID = item.ID;
                order2.CustomerName=item.CustomerName;
                order2.CustomerEmail=item.CustomerEmail;
                order2.CustomerAddress = item.CustomerAdress;
                order2.Status =;
                order2.OrderDate = item.OrderDate;
                order2.ShipDate= DateTime.Now;
                order2.DeliveryrDate = item.DeliveryrDate;
                order2.Items =;
                order2.TotalPrice =;
                dalOrder.Order.Update(order);
                return order2;
            }
            else
            {
                throw new BO.MyException("");
            }
        }



    }
    public Order updateOrderSupply(int orderNumber)
    {

    }
    public BO.OrderTracking getOrderTracking(int orderNumber)
    {

    }
}
