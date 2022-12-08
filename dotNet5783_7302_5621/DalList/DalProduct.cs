using DO;
using DalApi;
namespace Dal;
using System;
using static Dal.DataSource;
/// <summary>
/// the Implementations file of product
/// </summary>
internal class DalProduct: IProduct
{
    /// <summary>
    /// adding product to the product list
    /// </summary>
    public int Add(Product p)
    {
        for (int i = 0; i < productList.Count-1; i++)
        {
            if (p.ID == productList[i].ID)
            {
                throw new DalAlreadyExistsException("the product");
            }
        }
        p.ID = myRandom.Next(100000, 1000000);
        productList.Add(p);
        return p.ID;
    }
    /// <summary>
    /// deleting product from the product list
    /// </summary>
    public void Delete(int ID)
    {
        foreach(var item in productList)
        {
            if (ID == item.ID)
            {
                productList.Remove(item);
                return;
            }
        }
        throw new DalDoesNoExistException("the product");
    }

    /// <summary>
    /// updating product in the product list
    /// </summary>
    public void Update(Product p)
    {
        int counter = 0;
        foreach (var item in productList)
        {
            if (p.ID == item.ID)
            {
                productList[counter] = p;
                return;
            }
            counter++;
        }
        throw new DalDoesNoExistException("the product");
    }
    /// <summary>
    /// returning particular product by ID from the product list
    /// </summary>
    public Product Get(int ID)
    {
        foreach (var item in productList)
        {
            if (item.ID == ID)
                return item;
        }
        throw new DalDoesNoExistException("the product");
    }

    /// <summary>
    /// returning the all products in the product list
    /// </summary>
    public IEnumerable<Product> GetAll()
    {
        if (productList.Count == 0)
        {
            throw new DalDoesNoExistException("the product");
        }
        List<Product> newList = new List<Product>(productList.Count);
        foreach (var item in productList)
        {
            newList.Add(item);
        }
        return newList;
    }
}
