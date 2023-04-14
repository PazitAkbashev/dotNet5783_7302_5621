
using DO;
using DalList;
using DalApi;
using static Dal.DataSource;
using System.Collections.Generic;
using System;
using System.Collections;
namespace Dal;

/// <summary>
/// the order item implementation class
/// </summary>

internal class DalOrderItem : IOrderItem
{
    //adding an item to order
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
        //linq:
        //var itemsToRemove = orderItemList
        //.Where(item => ID == item?.ID);
        //if (itemsToRemove.Any())
        //{
        //    var itemToRemove = itemsToRemove.First();
        //    orderItemList.Remove(itemToRemove);
        //    return;
        //}
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
        //linq:
        //var itemToUpdate = orderItemList.Select((item, index) =>
        //new { Item = item, Index = index }).FirstOrDefault(x => o?.ID == x.Item?.ID);
        //if (itemToUpdate != null)
        //{
        //    orderItemList[itemToUpdate.Index] = o;
        //    return;
        //}
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
        return DataSource.orderItemList.Where(OrderItem => select is null
        ? true : select!(OrderItem));
    }

    public OrderItem GetSingle(Func<OrderItem?, bool>? select)
    {
        return GetAll(select).SingleOrDefault() ?? 
            throw new DalDoesNoExistException("Error-the order item does not exist");
    }
}

