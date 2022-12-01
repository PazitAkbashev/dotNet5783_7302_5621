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
 
internal class Product :IProduct
{
    private DalApi.IDal dalProduct = new Dal.DalList();
    public IEnumerable<BO.ProductForList> getProductList()
    {
        IEnumerable<DO.Product> tempList = dalProduct.Product.GetAll(); //creat list product type
        List<BO.ProductForList> productsForList=new List<BO.ProductForList>();  //?
        BO.ProductForList tempProduct = new BO.ProductForList();  //??
        foreach (var item in tempList)
        {
            tempProduct.ID= item.ID;
            tempProduct.Name= item.Name;
            tempProduct.Price= item.Price;
            tempProduct.category= item.Category;

        }
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
