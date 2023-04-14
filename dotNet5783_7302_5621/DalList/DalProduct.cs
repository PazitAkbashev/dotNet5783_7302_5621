using DO;
using DalApi;
namespace Dal;
using System;
using static Dal.DataSource;

/// <summary>
/// the product implementation class
/// functions on the product list
/// </summary>
internal class DalProduct : IProduct
{
    //adding a *new* product to the products list
    public int Add(Product p)
    {
        GetSingle(item => item?.ID == p.ID);
        //foreach (var item in productList)
        //{
        //    if (p.ID == item?.ID)
        //    {
        //        throw new DalAlreadyExistsException("the product");
        //    }
        //}
        for (int i = 0; i < productList.Count - 1; i++)
        {
            if (p.ID == productList[i]?.ID)
            {
                throw new DalAlreadyExistsException("the product");
            }
        }
        p.ID = myRandom.Next(100000, 1000000);
        productList.Add(p);
        return p.ID;
    }

    //deliting a product from the products list
    
    public void Delete(int ID)
    {
        if (!productList.Remove(GetSingle(item => item?.ID == ID)))
            throw new DalDoesNoExistException("the product"); //if remove function returned with false
    }

    //updating a product in the products list
    public void Update(Product? p)
    {
        int counter = 0;
        foreach (var item in productList)
        {
            if (p?.ID == item?.ID)
            {
                productList[counter] = p;
                return;
            }
            counter++;
        }
        throw new DalDoesNoExistException("the product");
    }

    public IEnumerable<Product?> GetAll(Func<Product?, bool>? select = null)
    {
        return DataSource.productList.Where(Product => select is null ? true : select!(Product));
    }

    public Product GetSingle(Func<Product?, bool>? select)
    {
        return GetAll(select).SingleOrDefault() ?? throw new DalDoesNoExistException("Error-the product does not exist");
    }
}
