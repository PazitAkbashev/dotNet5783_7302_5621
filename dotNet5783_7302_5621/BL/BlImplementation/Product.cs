﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using DalApi;
using Tools;
namespace BlImplementation;

internal class Product : BlApi.IProduct
{
    private DalApi.IDal dalProduct = new Dal.DalList();

    public IEnumerable<BO.ProductForList> getProductList()
    {
        try
        {
            IEnumerable<DO.Product> prod = dalProduct.Product.GetAll();
            List<BO.ProductForList> tempProdForList = new List<BO.ProductForList>();
            foreach (var item in prod)
            {
                BO.ProductForList tempProduct = new BO.ProductForList();
                tempProduct.ID = item.ID;
                tempProduct.Name = item.Name;
                tempProduct.Price = item.Price;
                tempProduct.category = item.Category;
                tempProdForList.Add(tempProduct);
            }
            return tempProdForList;
        }
        catch (DalApi.DalDoesNoExistException ex)
        {
            throw new BO.BoDoesNotExist("DO Exception", ex);
        }
    }

    public BO.Product getProductDetailsD(int productID)
    {
        try
        {
            productID.negativeNumber();
            BO.Product prod2 = new BO.Product();
            DO.Product prod = dalProduct.Product.Get(productID);
            prod2.ID = prod.ID;
            prod2.Name = prod.Name;
            prod2.InStock = prod.inStock;
            prod2.category = (BO.Enums.category)prod.Category;
            prod2.Price = prod.Price;
            return prod2;
        }
        catch (DalApi.DalDoesNoExistException ex)
        {
            throw new BO.BoDoesNotExist("DO Exception", ex);
        }
    }

    public BO.ProductItem getProductDetailsC(int productID, BO.Cart cart)
    {
        try
        {
            productID.negativeNumber();
            cart.CustomerName.notNull();
            cart.CustomerAddress.notNull();
            cart.CustomerEmail.notNull();
            BO.ProductItem tempProdItem = new BO.ProductItem();
            DO.Product tempProduct = dalProduct.Product.Get(productID);
            tempProdItem.ID = tempProduct.ID;
            tempProdItem.Name = tempProduct.Name;
            tempProdItem.Price = tempProduct.Price;
            tempProdItem.category = tempProduct.Category;
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

    public void addProduct(BO.Product product)
    {
        try
        {
            product.ID.negativeNumber();
            product.Price.negativeDoubleNum();
            product.Name.notNull();
            product.InStock.negativeNumber();
            DO.Product tempProduct = new DO.Product();
            tempProduct.ID = product.ID;
            tempProduct.Name = product.Name;
            tempProduct.Price = product.Price;
            tempProduct.inStock = product.InStock;
            tempProduct.Category = (DO.Enums.Category)product.category;
            dalProduct.Product.Add(tempProduct);
        }
        catch(DalApi.DalAlreadyExistsException ex)
        {
            throw new BO.BoAlreadyExist("DO Exception", ex);
        }
    }

    public void deleteProduct(int productID)
    {
        try
        {
            productID.negativeNumber();
            IEnumerable<DO.Order> tempList1 = dalProduct.Order.GetAll();
            IEnumerable<DO.Product> tempList2 = dalProduct.Product.GetAll();
            foreach (var item in tempList1)
            {
                productID.equalsNumbers(item.ID);
            }
            foreach (var item in tempList2)
            {
                if (item.ID == productID)
                {
                    break;
                }
            }
            dalProduct.Product.Delete(productID);
        }
        catch(DalApi.DalDoesNoExistException ex)
        {
            throw new BO.BoDoesNotExist("DO Exception", ex);
        }
    }

    public void updateProduct(BO.Product product)
    {
        try
        {
            product.ID.negativeNumber();
            product.Name.notNull();
            product.Price.negativeDoubleNum();
            product.InStock.negativeNumber();
            DO.Product tempProduct = new DO.Product();
            tempProduct.ID = product.ID;
            tempProduct.Name = product.Name;
            tempProduct.Price = product.Price;
            tempProduct.inStock = product.InStock;
            tempProduct.Category = (DO.Enums.Category)product.category;
            dalProduct.Product.Update(tempProduct);
        }
        catch (DalApi.DalDoesNoExistException ex)
        {
            throw new BO.BoDoesNotExist("DO Exception", ex);
        }
    }

}
