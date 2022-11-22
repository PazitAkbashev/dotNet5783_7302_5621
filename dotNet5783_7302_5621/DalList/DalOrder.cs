using System;
using DO;
using DalApi;
namespace Dal;
using static Dal.DataSource;

/// <summary>
/// the Implementations file of order
/// </summary>
public class DalOrder:IOrder
{
    /// <summary>
    /// adding an order to the orders array
    /// </summary>
    public int Add(Order o)
    {
        o.ID = myRandom.Next(100000, 1000000);
        orderList[orderList.Count] = o;
        return o.ID;
    }
    /// <summary>
    /// deleting an order from the orders array
    /// </summary>
    public void Delete(int ID)
    {
        for (int i = 0; i < orderList.Count; i++)
        {
            if (ID == orderList[i].ID)
            {
                orderList[i] = orderList[orderList.Count];
                return;
            }
        }
        throw new Exception("this order wasn't found");
    }
    /// <summary>
    /// updating an order in the orders array
    /// </summary>
    public void Update(Order o)
    {
        for (int i = 0; i < orderList.Count; i++)
        {
            if (o.ID == orderList[i].ID)
            {
                orderList[i] = o;
                return;
            }
        }
        throw new Exception("this order wasn't found");
    }
    /// <summary>
    /// getting an order from the orders array
    /// </summary>
    public Order Get(int index)
    {
        for (int i = 0; i < orderList.Count; i++)
        {
            if (index == orderList[i].ID)
                return orderList[i];
        }
        throw new Exception("this order wasn't found");
    }
}

