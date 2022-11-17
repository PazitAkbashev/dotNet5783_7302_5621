
using DO;
using System.Diagnostics;
using static DO.Enums;

namespace Dal;

internal static class DataSource
{
    internal static class Config
    {
        internal static int index1=0;
        internal static int index2 = 0;
        internal static int index3 = 0;
        private static int orderRunIndex = 100000;
        private static int orderItemRunIndex = 100000;
        static int getOrderRunIndex() { return ++orderRunIndex; }
        static int getorderItemRunIndex() { return ++orderItemRunIndex; }
    }
    static DataSource() { s_Initialize(); }  
    internal readonly static Random myRandom=new Random();
    internal static Product[] productArray = new Product[50];
    internal static Order[] orderArray=new Order[100];
    internal static OrderItem[] orderItemArray = new OrderItem[200];

    private static void  product_Initialize()
    {
        
        for (int i=0 ; i<10; i++)
        {
            Product product = new Product();
            product.Category = (Enums.Category)myRandom.Next(0, 5);
            product.ID = myRandom.Next(100000, 1000000);  
            for(int j=0 ; j<i; j++)
            {
                if (product.ID == productArray[j].ID)
                {
                    product.ID = myRandom.Next(100000, 1000000);
                    j=0;
                }
            }
            switch(product.Category)
            {
                case Enums.Starters:
                    product.Name = "" + (Enums.Starters)myRandom.Next(0, 4);
                    product.Price = myRandom.Next(50, 90);
                    break;
                case Enums.MainCourses:
                    product.Name = "" + (Enums.MainCourses)myRandom.Next(0, 4);
                    product.Price = myRandom.Next(100, 170);

                    break;
                case Enums.SideDishes:
                    product.Name = "" + (Enums.SideDishes)myRandom.Next(0, 4);
                    product.Price = myRandom.Next(30, 50);

                    break;
                case Enums.Drinks:
                    product.Name = "" + (Enums.Drinks)myRandom.Next(0, 4);
                    product.Price = myRandom.Next(25, 40);

                    break;
                case Enums.Deserts:
                    product.Name = "" + (Enums.Deserts)myRandom.Next(0, 4);
                    product.Price = myRandom.Next(30, 45);

                    break;
            }
            product.inStock = myRandom.Next(0, 50);
            productArray[i] = product;
        }
    }
   
    
    private static void order_Initialize()
    {
        for (int i = 0; i < 20; i++)
        {
            Order order = new Order();
            Order.ID = myRandom.Next(100000, 1000000);
            for (int j = 0; j < i; j++)
            {
                if (Order.ID == orderArray[j].ID)
                {
                    product.ID = myRandom.Next(100000, 1000000);
                    j = 0;
                }
            }

        }
    }

    private static void s_Initialize()
    {
        /*private static void*/ product_Initialize();
        /*private static void*/ order_Initialize();
       /* private static void*/ orderItem_Initialize();
    }

}
}
