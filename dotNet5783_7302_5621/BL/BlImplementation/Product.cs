using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;


namespace BlImplementation;
 
internal class Product :IProduct
{


    private DalApi.IDal dalProduct = new Dal.DalList();

    public IEnumerable<BO.ProductForList> getProductList()
    {
        IEnumerable<DO.Product> prod = dalProduct.Product.GetAll();  //asking for the product data.
        List<BO.ProductForList> tempProdForList = new List<BO.ProductForList>();
        foreach(var item in prod)
        {
            BO.ProductForList tempProduct = new ProductForList();
            tempProduct.ID = item.ID;
            tempProduct.Name = item.Name;
            tempProduct.Price=item.Price;
            tempProduct.category = item.Category;

            tempProdForList.Add(tempProduct);
        }
        return tempProdForList;
    }



    public BO.Product getProductDetailsD(int productID)
    {
        BO.Product prod2 = new BO.Product();
        if(productID > 0)
        {
            DO.Product prod = dalProduct.Product.Get(productID);   //asking for the product data.
            
            prod2.ID = prod.ID;
            prod2.Name = prod.Name;
            prod2.InStock = prod.inStock;
            prod2.category = prod.Category;
            prod2.Price = prod.Price;

        }

        return prod2; 
     
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
