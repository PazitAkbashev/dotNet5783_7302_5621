
namespace DalApi;
public interface ICrud<T>
{
    public void add(T t);
    public void delete(T t,int index);
    public void update(T t,int index);
    public T get(int index);
    //one more function here...
}
