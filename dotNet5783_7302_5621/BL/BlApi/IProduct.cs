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
public interface IProduct
{
    public IEnumerable<ProductForList> getProductList();
    public Product getProductDetailsD(int productID);
    public ProductItem getProductDetailsC(int productID);
    public void addProduct(IProduct product);
    public void deleteProduct(int productID);
    public void updateProduct(Product product);
}
