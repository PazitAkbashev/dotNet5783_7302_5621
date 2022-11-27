using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class ProductForList
{
    public int ID;
    public string Name;
    public double price;
    public Category category;

    public ProductForList getProductList();
}
