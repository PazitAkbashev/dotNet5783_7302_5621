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


    public Order Get(int ID)
    {
        foreach (var item in orderList)
        {
            if (item.ID == ID)
                return item;
        }
        throw new DalDoesNoExistException("the order");
    }
    public IEnumerable<Order> GetAll()
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

