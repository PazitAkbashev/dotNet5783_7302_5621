
using DO;
using DalList;
using DalApi;
using static Dal.DataSource;
using System.Collections.Generic;
using System;
namespace Dal;
/// <summary>
/// the Implementations file of order item
/// </summary>
internal class DalOrderItem : IOrderItem
{
    /// <summary>
    /// adding order item to the order items array
    /// </summary>
    public int Add(OrderItem o)
    {
        for (int i = 0; i < orderItemList.Count-1; i++)
        {
            if (o.ID == orderItemList[i].ID)
            {
                duplicationID d = new duplicationID();
                throw new Exception(d.ToString());
            }
        }
        o.ID = Config.getorderItemRunIndex();
        orderItemList.Add(o);
        return o.ID;
    }
    /// <summary>
    /// deleting order item from the order items array
    /// </summary>
    public void Delete( int ID)
    {
        for (int i = 0; i < orderItemList.Count-1; i++)
        {
            if(ID == orderItemList[i].ID)
            {
                orderItemList.Remove(orderItemList[i]);
                return;
            }
        }
        wasntFound w = new wasntFound();
        throw new Exception(w.ToString());
    }
    /// <summary>
    /// updating order item in the order items array
    /// </summary>
    public void Update(OrderItem o)
    {
        for (int i = 0; i < orderItemList.Count-1; i++)
        {
            if (o.ID == orderItemList[i].ID)
            {
                orderItemList[i] = o;
                return;
            }
        }
        wasntFound w = new wasntFound();
        throw new Exception(w.ToString());
    }
    /// <summary>
    /// getting an order item from the order items array 
    /// </summary>
    public OrderItem Get(int ID)
    {
        for (int i = 0; i < orderItemList.Count-1; i++)
        {
            if (orderList[i].ID == ID)
                return orderItemList[i];
        }
        wasntFound w = new wasntFound();
        throw new Exception(w.ToString());
    }
    /// <summary>
    /// getting the all order items from the order items array
    /// </summary>
    public List<OrderItem> GetAll()
    {
        if (orderItemList.Count == 0)
        {
            wasntFound w = new wasntFound();
            throw new Exception(w.ToString());
        }
        List<OrderItem> newList = new List<OrderItem>(orderItemList.Count);
        for (int i = 0; i < orderItemList.Count-1; i++)
        {
            newList.Add(orderItemList[i]);
        }
        return newList;  
    }
}

