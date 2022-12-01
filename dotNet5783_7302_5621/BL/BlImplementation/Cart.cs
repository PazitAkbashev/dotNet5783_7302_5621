using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using static BO.MyException;
//using DalApi;

namespace BlImplementation;

internal class Cart : BlApi.ICart
{
    private DalApi.IDal dalCart = new Dal.DalList();
    public BO.Cart addProductToCart(BO.Cart cart, int productID)
    {
        DO.Product tempProduct = dalCart.Product.Get(productID);
        bool flag = false;
        foreach(var item in cart.Items)
        {
            if(item.ProductID== productID)
            {
                flag = true;
                if (tempProduct.inStock > 0)
                {
                    item.Amount++;
                    item.TotalPrice += item.Price;
                    cart.TotalPrice += item.Price;
                }
                else
                    throw new BO.MyException("");  
            }
        }
        if(flag==false)
        {
            if (tempProduct.inStock > 0)
            {
                BO.OrderItem neworderitem=new BO.OrderItem();
                neworderitem.ProductID = productID; 
                neworderitem.Price=tempProduct.Price;
                neworderitem.TotalPrice = tempProduct.Price;
                neworderitem.Amount = 1;
                neworderitem.ProductName=tempProduct.Name;
                cart.Items.Add(neworderitem);
            }
            else
                throw new BO.MyException("");
        }
        return cart;
    }
    public BO.Cart updateAmountOfProduct(BO.Cart cart, int productID, int newAmount)
    {
        DO.Product tempProduct = dalCart.Product.Get(productID);
        foreach (var item in cart.Items)
        {
            if (item.ProductID == productID)
            {
                if (item.Amount < newAmount)
                {
                    if (tempProduct.inStock >= (newAmount - item.Amount))
                    {
                        item.Amount = newAmount;
                        item.TotalPrice += ((newAmount - item.Amount) * tempProduct.Price);
                        cart.TotalPrice += ((newAmount - item.Amount) * tempProduct.Price);
                    }
                    else
                        throw new BO.MyException("");
                }
                else
                {
                    if (item.Amount > newAmount)
                    {
                        item.Amount = newAmount;
                        item.TotalPrice -= ((item.Amount - newAmount) * tempProduct.Price);
                        cart.TotalPrice -= ((item.Amount - newAmount) * tempProduct.Price);
                    }
                    else
                    {
                        if (newAmount == 0)
                        {
                            BO.OrderItem neworderitem = new BO.OrderItem();
                            neworderitem.ProductID = tempProduct.ID;
                            neworderitem.Price = tempProduct.Price;
                            neworderitem.ProductName = tempProduct.Name;
                            //maby there are some details that miss
                            cart.Items.Remove(neworderitem);
                            cart.TotalPrice =0;
                        }
                        else
                        {
                            throw new BO.MyException("");
                        }
                    }
                }
            }
        }
        return cart;
    }
    public void confirmCart(Cart cart)
    {

    }
}
