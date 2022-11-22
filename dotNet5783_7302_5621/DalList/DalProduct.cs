using DO;
using DalApi;
namespace Dal;
using static Dal.DataSource;
/// <summary>
/// the Implementations file of product
/// </summary>
public class DalProduct: IProduct
{
    /// <summary>
    /// adding product to the products array
    /// </summary>
    public int Add(Product p)
    {
        p.ID = myRandom.Next(100000, 1000000);
        productList[productList.Count] = p;
        return p.ID;
    }
    /// <summary>
    /// deleting product from the products array
    /// </summary>
    public void Delete(int ID)
    {
        for (int i = 0; i < productList.Count; i++)
        {
            if (ID == productList[i].ID)
            {
                productList[i] = productList[productList.Count];
                return;
            }
        }
        throw new Exception("this product wasn't found");
    }
    /// <summary>
    /// updating product in the products array
    /// </summary>
    public void Update(Product p)
    {
        for (int i = 0; i < productList.Count; i++)
        {
            if (p.ID == productList[i].ID)
            {
                productList[i] = p;
                return;
            }
        }
        throw new Exception("this product wasn't found");
    }
    /// <summary>
    /// getting product from the products array
    /// </summary>
    public Product Get(int ID)
    {
        for (int i = 0; i < productList.Count; i++)
        {
            if (ID == productList[i].ID)
                return productList[i];
        }
        throw new Exception("this product wasn't found");
    }
}
