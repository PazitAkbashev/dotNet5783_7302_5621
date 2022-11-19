
using DO;
using DalApi;

namespace Dal;

public class DalOrderItem : IOrderItem
{
    public int add(OrderItem o)
    {
        for (int i = 0; i < DataSource.orderItemArray.Length; i++)
            if (o.ID == DataSource.orderItemArray[i].ID)
                throw new Exception("this product is already exsist");
        o.ID = DataSource.Config.getorderItemRunIndex();
        DataSource.orderItemArray[DataSource.orderItemArray.Length - 1] = o;
        return o.ID;
    }

    public void delete(OrderItem o, int index)
    {
        for (var i = 0; i < DataSource.; i++)  

    }
    public void update(OrderItem o, int index)
    {

    }
    public OrderItem get(int index)
    {
        for (int i = 0; i < DataSource.orderItemArray.Length - 1; i++)
        {
            if (index == DataSource.orderItemArray[i].ID)
                return DataSource.orderItemArray[i];
        }
        throw new Exception("this order doesn't exsist");
    }
    public OrderItem[] returnOrderItems(int orderNumber)
    {

    }
    public Product returnProduct(int orderNumber, int orderItemNumber)
    {

    }
}

