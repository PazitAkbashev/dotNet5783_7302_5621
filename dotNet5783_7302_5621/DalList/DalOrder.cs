using System;
using DO;
using DalList;
using DalApi;
using System.Collections.Generic;
namespace Dal;
using static Dal.DataSource;

/// <summary>
/// the Implementations file of order
/// </summary>
internal class DalOrder:IOrder
{
    /// <summary>
    /// adding an order to the order list
    /// </summary>
    public int Add(Order o)
    {
        foreach (var item in orderList)
        {
            if (o.ID == item.ID)
            {
                throw new DalAlreadyExistsException("the order");
            }
        }
        o.ID = myRandom.Next(100000, 1000000);
        orderList.Add(o);
        return o.ID;
    }
    /// <summary>
    /// deleting order from the order list
    /// </summary>
    public void Delete(int ID)
    {
        foreach (var item in orderList)
        {
            if (ID == item.ID)
            {
                orderList.Remove(item);
                return;
            }
        }
        throw new DalDoesNoExistException("the order");
    }
   
    /// <summary>
    /// updating order in the order list
    /// </summary>
    public void Update(Order o)
    {
        int counter = 0;
        foreach (var item in orderList)
        {
            if (o.ID == item.ID)
            {
                orderList[counter] = o;
                return;
            }
            counter++;
        }
        throw new DalDoesNoExistException("the order");
    }

    /// <summary>
    /// returning particular order by ID
    /// </summary>
    public Order Get(int ID)
    {
        foreach (var item in orderList)
        {
            if (item.ID == ID)
                return item;
        }
        throw new DalDoesNoExistException("the order");
    }

    /// <summary>
    /// returning the all orders in the list
    /// </summary>
    public IEnumerable<Order> GetAll(Func<Order?, bool> func = null)
    {
        if (orderList.Count == 0)
        {
            throw new DalDoesNoExistException("the order");
        }
        List<Order> newList = new List<Order>(orderList.Count);
        foreach (var item in orderList)
        {
            newList.Add(item);
        }
        return newList;
    }
}

