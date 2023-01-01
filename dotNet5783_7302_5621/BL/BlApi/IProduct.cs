using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;
/// <summary>
/// the product interface
/// </summary>
public interface IProduct
{
    public IEnumerable<BO.ProductForList> getProductList(Func<ProductForList, bool> func = null!);
    public Product getProductDetailsD(int productID);
    public ProductItem getProductDetailsC(int productID,Cart cart);
    public void addProduct(Product product);
    public void deleteProduct(int productID);
    public void updateProduct(Product product);
}
