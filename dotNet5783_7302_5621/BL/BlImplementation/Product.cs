using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using BO;
//using BO;
//using DalApi;

namespace BlImplementation;
 
internal class Product : /*BlApi.*/IProduct
{
    private DalApi.IDal dalProduct = new Dal.DalList();
    public IEnumerable<BO.ProductForList> getProductList()
    {
        IEnumerable<DO.Product> tempList = dalProduct.Product.GetAll();
        List<BO.ProductForList> productsForList=new List<BO.ProductForList>();
        ProductForList productForList = new ProductForList();
        for()


        return productsForList;
    }
    public Product getProductDetailsD(int productID)
    {

    }
    public BO.ProductItem getProductDetailsC(int productID)
    {

    }
    public void addProduct(Product product)
    {

    }
    public void deleteProduct(int productID)
    {

    }
    public void updateProduct(Product product)
    {

    }

}
