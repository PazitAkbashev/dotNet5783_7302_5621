
using DO;
using DalApi;
using static Dal.DataSource;
using System;
namespace Dal;

public class DalOrderItem : IOrderItem
{
    public int Add(OrderItem o)
    {
        o.ID = Config.getorderItemRunIndex();
        orderItemArray[Config._nextEmptyOrderItem++] = o;
        return o.ID;
    }

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

    public OrderItem Get(int index)
    {
        for (int i = 0; i < Config._nextEmptyOrderItem; i++)
        {
            if (index == orderItemArray[i].ID)
                return orderItemArray[i];
        }
        throw new Exception("this order item wasn't found");
    }

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

