using DO;
namespace DalApi;

public interface IOrderItem:ICrud<OrderItem>
{
    public OrderItem[] returnOrderItems(int orderNumber);
    public Product returnProduct(int orderNumber, int orderItemNumber);
}
