using System.Collections.Generic;
using System.Diagnostics;
using static DO.Enums;
using DO;
namespace Dal;

/// <summary>
/// definding the data source
/// ****************************should be replace be xaml file****************************
/// </summary>
internal static class DataSource
{
    static DataSource() { s_Initialize(); }

    internal readonly static Random myRandom = new Random();
   
    internal static List<DO.Product?> productList = new List<DO.Product?>(50);  //list of the product
    internal static List<DO.Order?> orderList = new List<DO.Order?>(100);  //list of the orderList
    internal static List<DO.OrderItem?> orderItemList = new List<DO.OrderItem?>(200); //list of the orderItems
 
    private static void  product_Initialize()
    {
        for (int i = 0; i < 10; i++) 
        {
            Product product = new Product();
            product.Category = (Enums.Category)myRandom.Next(0, 5);
            product.ID = myRandom.Next(100000, 1000000);  
            for(int j=0 ; j<i; j++)
            {
                if (product.ID == productList[j]?.ID)
                {
                    product.ID = myRandom.Next(100000, 1000000);
                    j=0;
                }
            }
            switch(product.Category)
            {
                case Enums.Category.Starters:
                    product.Name = "" + (Enums.Starters)myRandom.Next(0, 4);
                    product.Price = myRandom.Next(50, 90);
                    break;
                case Enums.Category.MainCourses:
                    product.Name = "" + (Enums.MainCourses)myRandom.Next(0, 4);
                    product.Price = myRandom.Next(100, 170);

                    break;
                case Enums.Category.SideDishes:
                    product.Name = "" + (Enums.SideDishes)myRandom.Next(0, 4);
                    product.Price = myRandom.Next(30, 50);
                                          
                    break;
                case Enums.Category.Drinks:
                    product.Name = "" + (Enums.Drinks)myRandom.Next(0, 4);
                    product.Price = myRandom.Next(25, 40);

                    break;
                case Enums.Category.Deserts:
                    product.Name = "" + (Enums.Deserts)myRandom.Next(0, 4);
                    product.Price = myRandom.Next(30, 45);

                    break;
            }
            product.inStock = myRandom.Next(0, 50);
            productList.Add(product);
        }
    }
    public static class Config
    {
        public static int orderRunIndex = 100000;

        public static int orderItemRunIndex = 100000;
        public static int getOrderRunIndex() { return ++orderRunIndex; }
        public static int getorderItemRunIndex() { return ++orderItemRunIndex; }
    }

    private static void order_Initialize()
    {
        string temp="a";
        for (int i = 0; i < 20; i++)
        {
            Order order = new Order();
            order.ID =Config.getOrderRunIndex();
            order.CustomerName = "" + (Enums.CustomerName)myRandom.Next(0, 10);
            order.CustomerEmail = order.CustomerName +temp+ "@gmail.com";
            temp+=1;
            order.CustomerAdress = "" + (Enums.CustomerAdress)myRandom.Next(0, 6);
            orderList.Add(order);
        }
    }

 
    private static void orderItem_Initialize()
    {
        for(int i=0;i<40;i++)
        {
            OrderItem orderItem = new OrderItem();

            Product? product = new Product();

            product = productList[myRandom.Next(0, productList.Count)];
            orderItem.ID = Config.getorderItemRunIndex();
            orderItem.ProductId = product?.ID??0;
            orderItem.OrderId = orderList[myRandom.Next(0, orderList.Count)]?.ID??0;
            orderItem.Amount = myRandom.Next(1, 5);
            orderItem.Price = orderItem.Amount * product?.Price??0;
            orderItemList.Add(orderItem);
        }
    }

    private static void s_Initialize()
    {
        product_Initialize();
        order_Initialize();
        orderItem_Initialize();
    }
}

