using DO;
namespace DalApi;

public interface IOrderItem:ICrud<OrderItem>
{
    public OrderItem[] GetAll();
}
