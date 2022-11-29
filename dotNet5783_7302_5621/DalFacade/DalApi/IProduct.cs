
using DO;
namespace DalApi;
/// <summary>
/// the product interface
/// </summary>

public interface IProduct:ICrud<Product>
{
    public IEnumerable<Product> GetAll();
}
