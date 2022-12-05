using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BO;
using DalApi;
using DO;

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
            tempOrder.ID=item.ID;
            tempOrder.CustomerName=item.CustomerName;
            if (item.OrderDate > DateTime.Now && item.ShipDate < DateTime.Now)
                tempOrder.Status = BO.Enums.orderStatus.Confirmed;
            if (item.ShipDate > DateTime.Now && item.DeliveryrDate < DateTime.Now)
                tempOrder.Status = BO.Enums.orderStatus.Shipped;
            if (item.DeliveryrDate > DateTime.Now)
                tempOrder.Status = BO.Enums.orderStatus.Supplied;
            double myTotalPrice = 0;
            int myAmountOfItems = 0;
            IEnumerable<DO.OrderItem> tempOrderItemList = dalOrder.OrderItem.GetAll();
            foreach (var item1 in tempOrderItemList)
            {
                if (item1.OrderId == item.ID)
                {
                    myTotalPrice += item1.Price;
                    myAmountOfItems++;
                }
            }
            tempOrder.AmountOfItems = myAmountOfItems;
            tempOrder.TotalPrice = myTotalPrice;
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
            if(item.ID== orderNumber&&item.ShipDate> DateTime.Now)
            {
                DO.Order order=item;
                order.ShipDate = DateTime.Now;
                BO.Order order2=new BO.Order();
                order2.ID = item.ID;
                order2.CustomerName=item.CustomerName;
                order2.CustomerEmail=item.CustomerEmail;
                order2.CustomerAddress = item.CustomerAdress;
                order2.Status =BO.Enums.orderStatus.Shipped;
                order2.OrderDate = item.OrderDate;
                order2.ShipDate= DateTime.Now;
                order2.DeliveryrDate = item.DeliveryrDate;
                IEnumerable<DO.OrderItem> orderItems = dalOrder.OrderItem.GetAll();
                double myTotalPrice = 0;
                foreach (var item2 in orderItems)
                {
                    myTotalPrice += item2.Price;
                    if (item2.ID== order2.ID)
                    {
                        BO.OrderItem myOrderItem = new BO.OrderItem();
                        myOrderItem.ID=item2.ID;
                        DO.Product myProduct = dalOrder.Product.Get(item2.ID);
                        myOrderItem.ProductName = myProduct.Name;
                        myOrderItem.ProductID = item2.ProductId;
                        myOrderItem.Price = item2.Price;
                        myOrderItem.Amount = item2.Amount;
                        myOrderItem.TotalPrice =item2.Price*item2.Amount;
                        order2.Items.Add(myOrderItem);
                    }
                }
                order2.TotalPrice = myTotalPrice;
                dalOrder.Order.Update(order);
                return order2;
            }
        }
        throw new BO.MyException("");
    }
    public BO.Order updateOrderSupply(int orderNumber)
    {
        IEnumerable<DO.Order> orders = dalOrder.Order.GetAll();
        foreach (var item in orders)
        {
            if (item.ID == orderNumber && item.ShipDate > DateTime.Now)
            {
                DO.Order order = item;
                order.DeliveryrDate = DateTime.Now;
                BO.Order order2 = new BO.Order();
                order2.ID = item.ID;
                order2.CustomerName = item.CustomerName;
                order2.CustomerEmail = item.CustomerEmail;
                order2.CustomerAddress = item.CustomerAdress;
                order2.Status = BO.Enums.orderStatus.Supplied;
                order2.OrderDate = item.OrderDate;
                order2.ShipDate = item.ShipDate;
                order2.DeliveryrDate = DateTime.Now;
                IEnumerable<DO.OrderItem> orderItems = dalOrder.OrderItem.GetAll();
                double myTotalPrice = 0;
                foreach (var item2 in orderItems)
                {
                    myTotalPrice += item2.Price;
                    if (item2.ID == order2.ID)
                    {
                        BO.OrderItem myOrderItem = new BO.OrderItem();
                        myOrderItem.ID = item2.ID;
                        DO.Product myProduct = dalOrder.Product.Get(item2.ID);
                        myOrderItem.ProductName = myProduct.Name;
                        myOrderItem.ProductID = item2.ProductId;
                        myOrderItem.Price = item2.Price;
                        myOrderItem.Amount = item2.Amount;
                        myOrderItem.TotalPrice = item2.Price * item2.Amount;
                        order2.Items.Add(myOrderItem);
                    }
                }
                order2.TotalPrice = myTotalPrice;
                dalOrder.Order.Update(order);
                return order2;
            }
        }
        throw new BO.MyException("");
    }
    public BO.OrderTracking getOrderTracking(int orderNumber)
    {
        IEnumerable<DO.Order> orders = dalOrder.Order.GetAll();
        foreach (var item in orders)
        {
            if(item.ID== orderNumber)
            {
                BO.OrderTracking myOrderTracking=new BO.OrderTracking();
                myOrderTracking.ID = item.ID;
                if (item.OrderDate > DateTime.Now && item.ShipDate < DateTime.Now)
                    myOrderTracking.Status = BO.Enums.orderStatus.Confirmed;
                if (item.ShipDate > DateTime.Now && item.DeliveryrDate < DateTime.Now)
                    myOrderTracking.Status = BO.Enums.orderStatus.Shipped;
                if (item.DeliveryrDate > DateTime.Now)
                    myOrderTracking.Status = BO.Enums.orderStatus.Supplied;
                /////////////////////////////////////////////////

                return myOrderTracking;
            }
        }
        throw new BO.MyException("");
    }
}
