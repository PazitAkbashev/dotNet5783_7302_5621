using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;
/// <summary>
/// 
/// </summary>
public interface ICart
{
    public Cart addProductToCart(Cart cart, int productID);
    public Cart updateAmountOfProduct(Cart cart, int productID, int newAmount);
    public void confirmCart(Cart cart);
}
