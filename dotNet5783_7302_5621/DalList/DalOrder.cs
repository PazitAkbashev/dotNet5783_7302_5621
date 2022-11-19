using System;
using DO;
using DalApi;
namespace Dal;
using static Dal.DataSource;


public class DalOrder:IOrder
{
    public int Add(Order o)
    {
        o.ID = myRandom.Next(100000, 1000000);
        orderArray[Config._nextEmptyOrder++] = o;
        return o.ID;
    }

    public void Delete(int ID)
    {
        for (int i = 0; i < Config._nextEmptyOrder; i++)
        {
            if (ID == orderArray[i].ID)
            {
                orderArray[i] = orderArray[--Config._nextEmptyOrder];
                return;
            }
        }
        throw new Exception("this order wasn't found");
    }

    public void Update(Order o)
    {
        for (int i = 0; i < Config._nextEmptyOrder; i++)
        {
            if (o.ID == orderArray[i].ID)
            {
                orderArray[i] = o;
                return;
            }
        }
        throw new Exception("this order wasn't found");
    }

    public Order Get(int index)
    {
        for (int i = 0; i < Config._nextEmptyOrder; i++)
        {
            if (index == orderArray[i].ID)
                return orderArray[i];
        }
        throw new Exception("this order wasn't found");
    }
}

