using DO;
using DalApi;
namespace Dal;
using static Dal.DataSource;


public class DalProduct: IProduct
{
    public int Add(Product p)
    {
        p.ID = myRandom.Next(100000, 1000000);
        productArray[Config._nextEmptyProduct++] = p;
        return p.ID;
    }

    public void Delete(int ID)
    {
        for (int i = 0; i < Config._nextEmptyProduct; i++)
        {
            if (ID == productArray[i].ID)
            {
                productArray[i] = productArray[--Config._nextEmptyProduct];
                return;
            }
        }
        throw new Exception("this product wasn't found");
    }

    public void Update(Product p)
    {
        for (int i = 0; i < Config._nextEmptyProduct; i++)
        {
            if (p.ID == productArray[i].ID)
            {
                productArray[i] = p;
                return;
            }
        }
        throw new Exception("this product wasn't found");
    }

    public Product Get(int index)
    {
        for (int i = 0; i < Config._nextEmptyProduct; i++)
        {
            if (index == productArray[i].ID)
                return productArray[i];
        }
        throw new Exception("this product wasn't found");
    }
}
