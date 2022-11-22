
using DO;
namespace DalApi;
/// <summary>
/// interface that including the 3 interfaces
/// </summary>
public interface IDal
{
    IOrder Order { get; }   
    IProduct Product { get; }
    IOrderItem OrderItem { get; }
}
