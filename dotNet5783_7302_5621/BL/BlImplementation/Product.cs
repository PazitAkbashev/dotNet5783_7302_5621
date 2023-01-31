using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BO;
using DalApi;
using Tools;
namespace BlImplementation;


/// <summary>
/// the product implementation class
/// </summary>
internal class Product : BlApi.IProduct
{
    private DalApi.IDal? dalProduct = DalApi.Factory.Get();
    /// <summary>
    /// returning the products list
    /// </summary>
    public IEnumerable<BO.ProductForList> getProductList(Func <ProductForList,bool> func= null!)
    {
        try
        {
            IEnumerable<DO.Product?> prod = dalProduct!.Product.GetAll();
            List<BO.ProductForList> tempProdForList = new List<BO.ProductForList>();
            
            //instead the foreach
            //var tempArr = from item in prod 
                        //  select new {ID=item?.ID??0,Name=item?.Name,Price=item?.Price??0, category = (BO.Enums.category)item?.Category!};

            foreach (var item in prod)
            {
                BO.ProductForList tempProduct = new BO.ProductForList();
                tempProduct.ID = item?.ID ?? 0;
                tempProduct.Name = item?.Name;
                tempProduct.Price = item?.Price ?? 0;
                tempProduct.category = (BO.Enums.category)item?.Category!;
                tempProdForList.Add(tempProduct);
            }

            return func  is null? tempProdForList : tempProdForList.Where(func);
        }
        catch (DalApi.DalDoesNoExistException ex)
        {
            throw new BO.BoDoesNotExist("DO Exception", ex);
        }
    }
    /// <summary>
    /// returning the product details
    /// </summary>
    public BO.Product getProductDetailsD(int productID)
    {
        try
        {
            productID.negativeNumber();
            BO.Product prod2 = new BO.Product();
            DO.Product prod = dalProduct!.Product.GetSingle(x => x?.ID == productID);
            prod2.ID = prod.ID;
            prod2.Name = prod.Name;
            prod2.InStock = prod.inStock;
            prod2.category = (BO.Enums.category)prod.Category!;
            prod2.Price = prod.Price;
            return prod2;
        }
        catch (DalApi.DalDoesNoExistException ex)
        {
            throw new BO.BoDoesNotExist("DO Exception", ex);
        }
    }
    /// <summary>
    /// returning the product details
    /// </summary>
    public BO.ProductItem getProductDetailsC(int productID, BO.Cart cart)
    {
        try
        {
            productID.negativeNumber();
            cart.CustomerName!.notNull();
            cart.CustomerAddress!.notNull();
            cart.CustomerEmail!.notNull();
            BO.ProductItem tempProdItem = new BO.ProductItem();
            DO.Product tempProduct = dalProduct!.Product.GetSingle(x => x?.ID == productID);
            tempProdItem.ID = tempProduct.ID;
            tempProdItem.Name = tempProduct.Name;
            tempProdItem.Price = tempProduct.Price;
            tempProdItem.category = tempProduct.Category??0;
            if (tempProduct.inStock > 0)
                tempProdItem.InStock = true;
            else
                tempProdItem.InStock = false;
            return tempProdItem;
        }
        catch(DalApi.DalDoesNoExistException ex)
        {
            throw new BO.BoDoesNotExist("DO Exception", ex);
        }
    }
    /// <summary>
    /// adding product to the products list
    /// </summary>
    public void addProduct(BO.Product product)
    {
        try
        {
            product.ID.negativeNumber();
            product.Price.negativeDoubleNum();
            product.Name!.notNull();
            product.InStock.negativeNumber();
            DO.Product tempProduct = new DO.Product();
            tempProduct.ID = product.ID;
            tempProduct.Name = product.Name;
            tempProduct.Price = product.Price;
            tempProduct.inStock = product.InStock;
            tempProduct.Category = (DO.Enums.Category)product.category;
            dalProduct!.Product.Add(tempProduct);
        }
        catch(DalApi.DalAlreadyExistsException ex)
        {
            throw new BO.BoAlreadyExist("the item is already exist", ex);
        }
    }
    /// <summary>
    /// deleting product from the list
    /// </summary>
    public void deleteProduct(int productID)
    {
        try
        {
            productID.negativeNumber();
            IEnumerable<DO.Order?> tempList1 = dalProduct!.Order.GetAll();
            IEnumerable<DO.Product?> tempList2 = dalProduct.Product.GetAll();



            foreach (var item in tempList1)
            {
                productID.equalsNumbers(item?.ID ?? 0);
            }
            foreach (var item in tempList2)
            {
                if (item?.ID == productID)
                {
                    break;
                }
            }
            dalProduct.Product.Delete(productID);
        }
        catch (DalApi.DalDoesNoExistException ex)
        {
            throw new BO.BoDoesNotExist("DO Exception", ex);
        }
    }
    /// <summary>
    /// updating product in the list
    /// </summary>
    public void updateProduct(BO.Product product)
    {
        try
        {
            product.ID.negativeNumber();
            product.Name!.notNull();
            product.Price.negativeDoubleNum();
            product.InStock.negativeNumber();
            DO.Product tempProduct = new DO.Product();
            tempProduct.ID = product.ID;
            tempProduct.Name = product.Name;
            tempProduct.Price = product.Price;
            tempProduct.inStock = product.InStock;
            tempProduct.Category = (DO.Enums.Category)product.category;
            dalProduct!.Product.Update(tempProduct);
        }
        catch (DalApi.DalDoesNoExistException ex)
        {
            throw new BO.BoDoesNotExist("DO Exception", ex);
        }
    }
}

