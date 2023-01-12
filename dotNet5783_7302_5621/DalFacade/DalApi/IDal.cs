
using DO;
namespace DalApi;

/// <summary>
/// (Application Program Interface : DL=>BL)
/// </summary>
public interface IDal 
{
    IOrder Order { get; }   
    IProduct Product { get; }
    IOrderItem OrderItem { get; }
}
