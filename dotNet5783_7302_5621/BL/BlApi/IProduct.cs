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
    public Product getProductDetails(int);
    public ProductItem getProductDetails(int);
    public void addProduct(IProduct);
    public void deleteProduct(int);
    public void updateProduct(Product);
}
