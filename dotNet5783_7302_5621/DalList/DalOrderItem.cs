
using DO;
using DalList;
using DalApi;
using static Dal.DataSource;
using System.Collections.Generic;
using System;
using System.Collections;

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
        foreach (var item in orderItemList)
        {
            if (o.ID == item.ID)
            {
                throw new DalAlreadyExistsException("the order item");
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
        foreach (var item in orderItemList)
        {
            if (ID == item.ID)
            {
                orderItemList.Remove(item);
                return;
            }
        }
        throw new DalDoesNoExistException("the order item");
    }
    /// <summary>
    /// updating order item in the order items array
    /// </summary>
    public void Update(OrderItem o)
    {
        int counter = 0;
        foreach (var item in orderItemList)
        {
            if (o.ID == item.ID)
            {
                orderItemList[counter] = o;
                return;
            }
            counter++;
        }
        throw new DalDoesNoExistException("the order item");
    }
    /// <summary>
    /// getting an order item from the order items array 
    /// </summary>
    public OrderItem Get(int ID)
    {
        foreach (var item in orderItemList)
        {
            if (item.ID == ID)
                return item;
        }
        throw new DalDoesNoExistException("the order item");
    }
    /// <summary>
    /// getting the all order items from the order items array
    /// </summary>
    public IEnumerable<OrderItem> GetAll()
    {
        if (orderItemList.Count == 0)
        {
            throw new DalDoesNoExistException("the order item");
        }
        List<OrderItem> newList = new List<OrderItem>(orderItemList.Count);
        foreach (var item in orderItemList)
        {
            newList.Add(item);
        }
        return newList;  
    }
}

