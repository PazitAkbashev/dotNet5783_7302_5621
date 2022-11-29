
namespace DalApi;
public interface ICrud<T>
{
    public int Add(T t);
    public void Delete(int index);
    public void Update(T t);
    public T Get(int ID);
}
