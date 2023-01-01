using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BO;
using Tools;
namespace BlImplementation;


/// <summary>
/// the cart implementation class
/// </summary>
internal class Cart : BlApi.ICart
{
    private DalApi.IDal? dalCart = DalApi.Factory.Get();
    /// <summary>
    /// adding product to cart
    /// </summary>
    public BO.Cart addProductToCart(BO.Cart cart, int productID)
    {
        try
        {
            productID.negativeNumber();
            cart.CustomerAddress!.notNull();
            cart.CustomerName!.notNull();
            cart.CustomerEmail!.notNull();
            DO.Product tempProduct = dalCart!.Product.GetSingle(x => x?.ID == productID);
            bool flag = false;
            foreach (var item in cart.Items!)
            {
                if (item.ProductID == productID)
                {
                    flag = true;
                    tempProduct.inStock.negativeNumber();
                    item.Amount++;
                    item.TotalPrice += item.Price;
                    cart.TotalPrice += item.Price;
                }
            }
            if (flag == false)
            {
                tempProduct.inStock.negativeNumber();
                BO.OrderItem neworderitem = new BO.OrderItem();
                neworderitem.ProductID = productID;
                neworderitem.Price = tempProduct.Price;
                neworderitem.TotalPrice = tempProduct.Price;
                neworderitem.Amount = 1;
                neworderitem.ProductName = tempProduct.Name;
                cart.Items.Add(neworderitem);
            }
            return cart;
        }
        catch (DalApi.DalDoesNoExistException ex)
        {
            throw new BO.BoDoesNotExist("DO Exception", ex);
        }
    }

    /// <summary>
    /// updating the amount of products
    /// </summary>
    public BO.Cart updateAmountOfProduct(BO.Cart cart, int productID, int newAmount)
    {
        try
        {
            cart.CustomerAddress!.notNull();
            cart.CustomerName!.notNull();
            cart.CustomerEmail!.notNull();
            productID.negativeNumber();
            newAmount.negativeNumber();
            DO.Product tempProduct = dalCart!.Product.GetSingle(x => x?.ID == productID);
            foreach (var item in cart.Items!)
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
                                cart.Items.Remove(neworderitem);
                                cart.TotalPrice = 0;
                            }
                        }
                    }
                }
            }
            return cart;
        }
        catch (DalApi.DalDoesNoExistException ex)
        {
            throw new BO.BoDoesNotExist("DO Exception", ex);
        }
    }

    /// <summary>
    ///confirming the order and cart 
    /// </summary>
    public void confirmCart(BO.Cart cart)
    {
        try
        {
            cart.CustomerAddress!.notNull();
            cart.CustomerName!.notNull();
            cart.CustomerEmail!.notNull();
            foreach (var item in cart.Items!)
            {
                DO.Product tempProduct = dalCart!.Product.GetSingle(x => x?.ID ==item.ID);
                item.Amount.negativeNumber();
                tempProduct.inStock.inStockSmallerThanAmount(item.Amount);
            }
            DO.Order tempOrder = new DO.Order();
            tempOrder.CustomerName = cart.CustomerName;
            tempOrder.CustomerAdress = cart.CustomerAddress;
            tempOrder.CustomerEmail = cart.CustomerEmail;
            tempOrder.OrderDate = DateTime.Now;
            tempOrder.ShipDate = DateTime.MinValue;
            tempOrder.DeliveryrDate = DateTime.MinValue;
            int returnID;
            try
            {
                returnID = dalCart!.Order.Add(tempOrder);
            }
            catch (DalApi.DalAlreadyExistsException ex)
            {
                throw new BO.BoAlreadyExist("DO Exception", ex);
            }
            foreach (var item in cart.Items)
            {
                DO.OrderItem tempOrderItem = new DO.OrderItem();
                tempOrderItem.ID = item.ID;
                tempOrderItem.Price = item.Price;
                tempOrderItem.Amount = item.Amount;
                tempOrderItem.ProductId = item.ProductID;
                tempOrderItem.OrderId = returnID;
                try
                {
                    dalCart.OrderItem.Add(tempOrderItem);
                }
                catch (DalApi.DalAlreadyExistsException ex)
                {
                    throw new BO.BoAlreadyExist("DO Exception", ex);
                }
            }
        }
        catch (DalApi.DalDoesNoExistException ex)
        {
            throw new BO.BoDoesNotExist("DO Exception", ex);
        }
    }
}
