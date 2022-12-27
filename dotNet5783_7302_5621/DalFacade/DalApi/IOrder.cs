
using DO;
namespace DalApi;

/// <summary>
/// the order interface
/// </summary>
public interface IOrder:ICrud<Order>
{
    public IEnumerable<Order?> GetAll(Func<Order?, bool> func = null);
}
