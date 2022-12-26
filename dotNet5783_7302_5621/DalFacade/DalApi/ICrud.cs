
using DO;

namespace DalApi;

/// <summary>
/// the main Dal interface
/// </summary>
public interface ICrud<T>
{
    public int Add(T t);
    public void Delete(int index);
    public void Update(T t);
    public T Get(int ID);
    public IEnumerable<T?> GetAll(Func<T?,bool>func=null);

}
