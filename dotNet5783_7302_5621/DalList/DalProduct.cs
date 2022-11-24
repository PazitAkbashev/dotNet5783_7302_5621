using DO;
using DalApi;
namespace Dal;
using DalList;
using System;
using static Dal.DataSource;
/// <summary>
/// the Implementations file of product
/// </summary>
internal class DalProduct: IProduct
{
    /// <summary>
    /// adding product to the products array
    /// </summary>
    public int Add(Product p)
    {
        for (int i = 0; i < productList.Count-1; i++)
        {
            if (p.ID == productList[i].ID)
            {
                duplicationID d = new duplicationID();
                throw new Exception(d.ToString());
            }
        }
        p.ID = myRandom.Next(100000, 1000000);
        productList.Add(p);
        return p.ID;
    }
    /// <summary>
    /// deleting product from the products array
    /// </summary>
    public void Delete(int ID)
    {
        for (int i = 0; i < productList.Count-1; i++)
        {
            if (ID == productList[i].ID)
            {
                productList.Remove(productList[i]);
                return;
            }
        }
        wasntFound w = new wasntFound();
        throw new Exception(w.ToString());
    }
    /// <summary>
    /// updating product in the products array
    /// </summary>
    public void Update(Product p)
    {
        for (int i = 0; i < productList.Count-1; i++)
        {
            if (p.ID == productList[i].ID)
            {
                productList[i] = p;
                return;
            }
        }
        wasntFound w = new wasntFound();
        throw new Exception(w.ToString());
    }
    /// <summary>
    /// getting product from the products array
    /// </summary>
    public Product Get(int ID)
    {
        for (int i = 0; i < productList.Count-1; i++)
        {
            if (productList[i].ID == ID)
                return productList[i];
        }
        wasntFound w = new wasntFound();
        throw new Exception(w.ToString());
    }
}
