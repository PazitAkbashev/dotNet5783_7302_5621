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
        DO.Product prod = dalCart.Product.Get(productID);
        bool flag = false;
        foreach(var item in cart.Items)
        {
            if(item.ProductID== productID)
            {
                flag = true;
                if (prod.inStock > 0)
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
            if (prod.inStock > 0)
            {
                BO.OrderItem neworderitem=new BO.OrderItem();
                neworderitem.ProductID = productID; 
                neworderitem.Price=prod.Price;
                neworderitem.TotalPrice = prod.Price;
                neworderitem.Amount = 1;
                neworderitem.ProductName=prod.Name;
                cart.Items.Add(neworderitem);
            }
            else
                throw new BO.MyException("");
        }
        return cart;
    }
    public Cart updateAmountOfProduct(Cart cart, int productID, int newAmount)
    {

    }
    public void confirmCart(Cart cart)
    {

    }
}
