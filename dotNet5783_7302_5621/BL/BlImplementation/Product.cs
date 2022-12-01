using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;


namespace BlImplementation;
 
internal class Product :IProduct
{
    private DalApi.IDal dalProduct = new Dal.DalList();

    public IEnumerable<BO.ProductForList> getProductList()
    {
        IEnumerable<DO.Product> prod = dalProduct.Product.GetAll();  
        List<BO.ProductForList> tempProdForList = new List<BO.ProductForList>();
        foreach(var item in prod)
        {
            BO.ProductForList tempProduct = new BO.ProductForList();
            tempProduct.ID = item.ID;
            tempProduct.Name = item.Name;
            tempProduct.Price=item.Price;
            tempProduct.category = item.Category;

            tempProdForList.Add(tempProduct);
        }
        return tempProdForList;
    }

    public BO.Product getProductDetailsD(int productID)
    {
        BO.Product prod2 = new BO.Product();
        if(productID > 0)
        {
            DO.Product prod = dalProduct.Product.Get(productID);  
            
            prod2.ID = prod.ID;
            prod2.Name = prod.Name;
            prod2.InStock = prod.inStock;
            prod2.category = prod.Category;
            prod2.Price = prod.Price;
        }
        return prod2; 
    }   

    public BO.ProductItem getProductDetailsC(int productID,Cart cart)
    {
        BO.ProductItem tempProdItem = new BO.ProductItem();
        if (productID>0)
        {
            DO.Product tempProduct = dalProduct.Product.Get(productID);
            tempProdItem.ID = tempProduct.ID;
            tempProdItem.Name=tempProduct.Name;
            tempProdItem.Price=tempProduct.Price;
            tempProdItem.category=tempProduct.Category;
            if (tempProduct.inStock > 0)
                tempProdItem.InStock = true;
            else
                tempProdItem.InStock = false;
        }
        else
        {
            throw new BO.MyException("");
        }
        return tempProdItem;
    }

    public void addProduct(BO.Product product)
    {
        if(product.ID<=0)
            throw new BO.MyException("");
        if(string.IsNullOrEmpty(product.Name))
            throw new BO.MyException("");
        if(product.Price<=0)
            throw new BO.MyException("");
        if(product.InStock<0)
            throw new BO.MyException("");
        DO.Product tempProduct = new DO.Product();
        tempProduct.ID = product.ID;
        tempProduct.Name = product.Name;
        tempProduct.Price = product.Price;
        tempProduct.inStock = product.InStock;
        tempProduct.Category = product.category;
        try
        {
            dalProduct.Product.Add(tempProduct);
        }
        catch(Exception ex)
        {
            throw new BO.MyException("");
        }
    }

    public void deleteProduct(int productID)
    {
        
    }

    public void updateProduct(BO.Product product)
    {
        if (product.ID <= 0)
            throw new BO.MyException("");
        if (string.IsNullOrEmpty(product.Name))
            throw new BO.MyException("");
        if (product.Price <= 0)
            throw new BO.MyException("");
        if (product.InStock < 0)
            throw new BO.MyException("");
        DO.Product tempProduct = new DO.Product();
        tempProduct.ID = product.ID;
        tempProduct.Name = product.Name;
        tempProduct.Price = product.Price;
        tempProduct.inStock = product.InStock;
        tempProduct.Category = product.category;
        try
        {
            dalProduct.Product.Update(tempProduct);
        }
        catch (Exception ex)
        {
            throw new BO.MyException("");
        }
    }

}
