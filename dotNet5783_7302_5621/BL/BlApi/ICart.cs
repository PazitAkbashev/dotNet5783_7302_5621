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
    public Cart addProductToCart(Cart, int);
    public Cart updateAmountOfProduct(Cart, int, int);
    public void confirmCart(Cart);
}
