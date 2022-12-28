
using DO;
using DalList;
using DalApi;
using static Dal.DataSource;
using System.Collections.Generic;
using System;
using System.Collections;
namespace Dal;


internal class DalOrderItem : IOrderItem
{
    public int Add(OrderItem o)
    {
        foreach (var item in orderItemList)
        {
            if (o.ID == item?.ID)
            {
                throw new DalAlreadyExistsException("the order item");
            }
        }
        o.ID = Config.getorderItemRunIndex();
        orderItemList.Add(o);
        return o.ID;
    }

    public void Delete( int ID)
    {
        foreach (var item in orderItemList)
        {
            if (ID == item?.ID)
            {
                orderItemList.Remove(item);
                return;
            }
        }
        throw new DalDoesNoExistException("the order item");
    }
 
    public void Update(OrderItem? o)
    {
        int counter = 0;
        foreach (var item in orderItemList)
        {
            if (o?.ID == item?.ID)
            {
                orderItemList[counter] = o;
                return;
            }
            counter++;
        }
        throw new DalDoesNoExistException("the order item");
    }
   
    public IEnumerable<OrderItem?> GetAll(Func<OrderItem?, bool>? select = null)
    {
        return DataSource.orderItemList.Where(OrderItem => select is null ? true : select!(OrderItem));
    }

    public OrderItem GetSingle(Func<OrderItem?, bool>? select)
    {
        return GetAll(select).SingleOrDefault() ?? throw new DalDoesNoExistException("Error-the order item does not exist");
    }
}

