using System;
using DO;
using DalList;
using DalApi;
using System.Collections.Generic;
namespace Dal;
using static Dal.DataSource;


internal class DalOrder:IOrder
{
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

    public IEnumerable<Order?> GetAll(Func<Order?, bool>? select = null)
    {
        return DataSource.orderList.Where(Order => select is null ? true : select!(Order));
    }

    public Order GetSingle(Func<Order?, bool>? select)
    {
        return GetAll(select).SingleOrDefault() ?? throw new DalDoesNoExistException("Error-the order does not exist");
    }
}

