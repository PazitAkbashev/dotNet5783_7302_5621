
using DO;
using System.Diagnostics;
using static DO.Enums;
namespace Dal;

internal static class DataSource
{
    public static class Config
    {
        internal static int _nextEmptyOrder=0;
        internal static int _nextEmptyOrderItem = 0;
        internal static int _nextEmptyProduct = 0;
        public static int orderRunIndex = 100000;
        public static int orderItemRunIndex = 100000;
        public static int getOrderRunIndex() { return ++orderRunIndex; }
        public static int getorderItemRunIndex() { return ++orderItemRunIndex; }
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
            productArray[Config._nextEmptyProduct++] = product;
        }
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
            orderArray[Config._nextEmptyOrder++] = order;

        }

    }
    private static void orderItem_Initialize()
    {
        for(int i=0;i<40;i++)
        {
            OrderItem orderItem = new OrderItem();
            Product product = new Product();
            product = productArray[myRandom.Next(0, Config._nextEmptyProduct)];

            orderItem.ID = Config.getorderItemRunIndex();
            orderItem.ProductId = product.ID;
            orderItem.OrderId = orderArray[myRandom.Next(0, Config._nextEmptyOrder)].ID;
            orderItem.Amount = myRandom.Next(1, 5);
            orderItem.Price = orderItem.Amount * product.Price;
            orderItemArray[Config._nextEmptyOrderItem++] = orderItem;
        }
    }

    private static void s_Initialize()
    {
        product_Initialize();
        order_Initialize();
        orderItem_Initialize();
    }

}

