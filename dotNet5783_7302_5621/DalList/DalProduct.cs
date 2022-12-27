using DO;
using DalApi;
namespace Dal;
using System;
using static Dal.DataSource;


internal class DalProduct: IProduct
{
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

    public IEnumerable<Product?> GetAll(Func<Product?, bool>? select = null)
    {
        return DataSource.productList.Where(Product => select is null ? true : select!(Product));
    }

    public Product GetSingle(Func<Product?, bool>? select)
    {
        return GetAll(select).SingleOrDefault() ?? throw new DalDoesNoExistException("Error-the product does not exist");
    }
}
