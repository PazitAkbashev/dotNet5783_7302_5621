using DO;
namespace DalApi;
/// <summary>
/// the order item interface
/// </summary>
public interface IOrderItem:ICrud<OrderItem>
{
    public OrderItem[] GetAll();
}
