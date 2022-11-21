using Dal;
using DO;
using DalApi;
using DalList;
using System.Text;
namespace DalTest;

public class Program
{
    private DalProduct p = new Product;
    private DalOrder o1 = new Order;
    private DalOrderItem o2 = new OrderItem;

    static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.WriteLine("Please enter your choice:");
            Console.WriteLine("0 to Exit");
            Console.WriteLine("1 to Product");
            Console.WriteLine("2 to Order");
            Console.WriteLine("3 to Order-Item");
            choice = Console.Read();
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("Enter your choice:");
                    Console.WriteLine("1 to add a product");
                    Console.WriteLine("2 to delete a product");
                    Console.WriteLine("3 to update a product");
                    Console.WriteLine("4 to get a product");
                    choice = Console.Read();
                    switch(choice)
                    {
                        case 1:
                            Console.WriteLine("Enter the product to add:");
                            Product myP;
                            myP= Console.ReadLine();
                            
                            break;
                        case 2:
                            Console.WriteLine("Enter the ID of the product to delete:");
                            int ID;
                            ID= Console.Read();

                            break;

                    }


                    break;

            }



        } while (choice != 0);

    }
}




    
   




