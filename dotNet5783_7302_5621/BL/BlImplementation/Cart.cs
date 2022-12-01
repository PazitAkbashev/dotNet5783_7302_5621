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
    public void confirmCart(BO.Cart cart)
    {
        if(string.IsNullOrEmpty(cart.CustomerName))
            throw new BO.MyException("");
        
        if (string.IsNullOrEmpty(cart.CustomerAddress))
            throw new BO.MyException("");
        
        if (string.IsNullOrEmpty(cart.CustomerEmail)||!cart.CustomerEmail.Contains("@gmail.com"))
            throw new BO.MyException("");
     
        foreach(var item in cart.Items)
        {
            DO.Product tempProduct = dalCart.Product.Get(item.ID);
            if (item.Amount <= 0)
                throw new BO.MyException("");

            if (tempProduct.inStock < item.Amount)
                throw new BO.MyException("");
            try
            {
                tempProduct = dalCart.Product.Get(item.ID);
            }
            catch(Exception ex)
            {
                throw new BO.MyException("");
            }
        }
        DO.Order tempOrder = new DO.Order();
        tempOrder.CustomerName = cart.CustomerName;
        tempOrder.CustomerAdress = cart.CustomerAddress;
        tempOrder.CustomerEmail = cart.CustomerEmail;
        tempOrder.OrderDate = DateTime.Now;
        tempOrder.ShipDate = DateTime.MinValue;
        tempOrder.DeliveryrDate= DateTime.MinValue;
        int returnID;
        try
        {
            returnID = dalCart.Order.Add(tempOrder);
        }
        catch(Exception ex)
        {
            throw new BO.MyException("");
        }
        foreach(var item in cart.Items)
        {
            DO.OrderItem tempOrderItem=new DO.OrderItem();
            tempOrderItem.ID=item.ID;
            tempOrderItem.Price=item.Price;
            tempOrderItem.Amount=item.Amount;
            tempOrderItem.ProductId = item.ProductID;
            tempOrderItem.OrderId = returnID;
            try
            {
                dalCart.OrderItem.Add(tempOrderItem);
            }
            catch (Exception ex)
            {
                throw new BO.MyException("");
            }
            DO.Product tempProduct = dalCart.Product.Get(item.ID);
            tempProduct.inStock -= item.Amount;
        }
    }
}
