
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
        orderItemArray[Config._nextEmptyOrderItem++] = o;
        return o.ID;
    }
    /// <summary>
    /// deleting order item from the order items array
    /// </summary>
    public void Delete( int ID)
    {
        for (int i = 0; i < Config._nextEmptyOrderItem; i++)
        {
            if(ID == orderItemArray[i].ID)
            {
                orderItemArray[i] = orderItemArray[--Config._nextEmptyOrderItem];
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
        for (int i = 0; i < Config._nextEmptyOrderItem; i++)
        {
            if (o.ID == orderItemArray[i].ID)
            {
                orderItemArray[i] = o;
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
        for (int i = 0; i < Config._nextEmptyOrderItem; i++)
        {
            if (index == orderItemArray[i].ID)
                return orderItemArray[i];
        }
        throw new Exception("this order item wasn't found");
    }
    /// <summary>
    /// getting the all order items from the order items array
    /// </summary>
    public OrderItem[] GetAll()
    {
        if (Config._nextEmptyOrderItem == 0)
            throw new Exception("there are no order items");
        OrderItem[] newArr = new OrderItem[Config._nextEmptyOrderItem];
        for (int i = 0; i < Config._nextEmptyOrderItem; i++)
        {
            newArr[i] = orderItemArray[i];
        }
        return newArr;  
    }
}

