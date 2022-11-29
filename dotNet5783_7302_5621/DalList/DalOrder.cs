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
    /// adding an order to the orders array
    /// </summary>
    public int Add(Order o)
    {
        for (int i=0;i<orderList.Count-1;i++)
        {
            if (o.ID == orderList[i].ID)
            {
                duplicationID d =new duplicationID();
                throw new Exception(d.ToString());
            }
        }
        o.ID = myRandom.Next(100000, 1000000);
        orderList.Add(o);
        return o.ID;
    }
    /// <summary>
    /// deleting an order from the orders array
    /// </summary>
    public void Delete(int ID)
    {
        for (int i = 0; i < orderList.Count-1; i++)
        {
            if (ID == orderList[i].ID)
            {
                orderList.Remove(orderList[i]);
                return;
            }
        }
        wasntFound w = new wasntFound();
        throw new Exception(w.ToString());
    }
    /// <summary>
    /// updating an order in the orders array
    /// </summary>
    public void Update(Order o)
    {
        for (int i = 0; i < orderList.Count-1; i++)
        {
            if (o.ID == orderList[i].ID)
            {
                orderList[i] = o;
                return;
            }
        }
        wasntFound w = new wasntFound();
        throw new Exception(w.ToString());
    }
    /// <summary>
    /// getting an order from the orders array
    /// </summary>
    public Order Get(int ID)
    {
        for (int i = 0; i < orderList.Count-1; i++)
        {
            if (orderList[i].ID == ID)
                return orderList[i];
        }
        wasntFound w = new wasntFound();
        throw new Exception(w.ToString());
    }
    public IEnumerable<Order> GetAll()
    {
        if (orderList.Count == 0)
        {
            wasntFound w = new wasntFound();
            throw new Exception(w.ToString());
        }
        List<Order> newList = new List<Order>(orderList.Count);
        for (int i = 0; i < orderList.Count - 1; i++)
        {
            newList.Add(orderList[i]);
        }
        return newList;
    }
}

