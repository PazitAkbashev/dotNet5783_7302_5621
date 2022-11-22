
using DO;
using DalApi;
using static Dal.DataSource;
using System;
namespace Dal;
/// <summary>
/// the Implementations file of order item
/// </summary>
public class DalOrderItem : IOrderItem
{
    /// <summary>
    /// adding order item to the order items array
    /// </summary>
    public int Add(OrderItem o)
    {
        o.ID = Config.getorderItemRunIndex();
        orderItemList[orderItemList.Count] = o;
        return o.ID;
    }
    /// <summary>
    /// deleting order item from the order items array
    /// </summary>
    public void Delete( int ID)
    {
        for (int i = 0; i < orderItemList.Count; i++)
        {
            if(ID == orderItemList[i].ID)
            {
                orderItemList[i] = orderItemList[orderItemList.Count];
                return;
            }
        }
        throw new Exception("this order item wasn't found");
    }
    /// <summary>
    /// updating order item in the order items array
    /// </summary>
    public void Update(OrderItem o)
    {
        for (int i = 0; i < orderItemList.Count; i++)
        {
            if (o.ID == orderItemList[i].ID)
            {
                orderItemList[i] = o;
                return;
            }
        }
        throw new Exception("this order item wasn't found");
    }
    /// <summary>
    /// getting an order item from the order items array 
    /// </summary>
    public OrderItem Get(int index)
    {
        for (int i = 0; i < orderItemList.Count; i++)
        {
            if (index == orderItemList[i].ID)
                return orderItemList[i];
        }
        throw new Exception("this order item wasn't found");
    }
    /// <summary>
    /// getting the all order items from the order items array
    /// </summary>
    public OrderItem[] GetAll()
    {
        if (orderItemList.Count == 0)
            throw new Exception("there are no order items");
        OrderItem[] newArr = new OrderItem[orderItemList.Count];
        for (int i = 0; i < orderItemList.Count; i++)
        {
            newArr[i] = orderItemList[i];
        }
        return newArr;  
    }
}

