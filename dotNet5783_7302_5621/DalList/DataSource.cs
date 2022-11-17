//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using DO;
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
    static DataSource() { s_Initialize(); }  //empty c-tor
    internal readonly static Random myRandom=new Random();
    internal static Product[] productArray = new Product[50];
    internal static Order[] orderArray=new Order[100];
    internal static OrderItem[] orderItemArray = new OrderItem[200];

    private static void addProduct(Product p)
    {
        productArray[productArray.Length] = p;
    }
    private static void addOrder(Order o)
    {
        orderArray[orderArray.Length] = o;

    }
    private static void addOrderItem(OrderItem o)
    {
        orderItemArray[orderItemArray.Length] = o;

    }
    private static void s_Initialize()
    {
        int myNum = 1234567;
        for (int i=0;i<10;i++)
        {
            Product p= new Product();
            p.ID = myNum + i;


           
        }
    }
}
