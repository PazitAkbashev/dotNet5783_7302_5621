using System;
using DO;
using DalList;
using DalApi;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Reflection;

namespace Dal;
using static Dal.DataSource;

/// <summary>
/// the order implementation class
/// </summary>
internal class DalOrder:IOrder
{ 
    //adding *new* order to the order list
    public int Add(Order o)
    {//if order already exist
    
        foreach (var item in orderList) 
        {
            if (o.ID == item?.ID)  
            {
                throw new DalAlreadyExistsException("the order");
            }
        }
        o.ID = myRandom.Next(100000, 1000000);  //if not exist giving random ID contain 6 digits
        orderList.Add(o);  //call itself again to check the ID does'nt exist yet
        return o.ID;
    }

    //deleting order from the order list 
    public void Delete(int ID)
    {
        orderList.Remove(GetSingle(item => item?.ID == ID));
        throw new DalDoesNoExistException("the order");  //f the order does'nt exist at all
    }

   //update existing order in the order list
    public void Update(Order? o)
    {
        int counter = 0;
        foreach (var item in orderList)
        {
            if (o?.ID == item?.ID)  //identify by ID wich is 'key'
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

    public Order GetSingle(Func<Order?, bool>? select) //may be use to get value from DL easly, return order
    {
        return GetAll(select).SingleOrDefault() ?? throw new DalDoesNoExistException("Error-the order does not exist");
    }
}

