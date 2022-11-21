using Dal;
using DO;
using System.Collections.Generic;
using static DO.Enums;
//using DalApi;
//using DalList;
//using System.Text;
//using System.ComponentModel;
//namespace Dal;


public class Program
{
    DalProduct dalProduct = new DalProduct();

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
                            Console.WriteLine("Enter the details of the product to add:");
                            Product myP=new Product();
                            myP.Name=Console.ReadLine();
                            myP.Category = (Category)int.Parse(Console.ReadLine());
                            myP.Price = Console.Read();
                            Console.WriteLine($"The product ID is:{DalProduct.Add(myP)}");
                            break;
                        case 2:
                            Console.WriteLine("Enter the ID of the product to delete:");
                            int ID;
                            ID= Console.Read();
                            //לשלוח למחיקה
                            break;
                        case 3:
                            Console.WriteLine("Enter the details of the product to update:");
                            Product myP2 = new Product();
                            myP2.Name = Console.ReadLine();
                            myP2.Category = (Category)int.Parse(Console.ReadLine());
                            myP2.Price = Console.Read();
                            //לשלוח לעידכון
                            break;
                        case 4:
                            Console.WriteLine("Enter the ID of the product to get:");
                            int ID3;
                            ID3 = Console.Read();
                            Console.WriteLine(DalProduct.Get(ID3));
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter your choice:");
                    Console.WriteLine("1 to add an order");
                    Console.WriteLine("2 to delete an order");
                    Console.WriteLine("3 to update an order");
                    Console.WriteLine("4 to get an order");
                    choice = Console.Read();
                    switch(choice)
                    {
                        case 1:
                            Console.WriteLine("Enter details of the order to add:");
                            Order myO = new Order();
                            myO.CustomerName = Console.ReadLine();
                            myO.CustomerEmail = Console.ReadLine();
                            myO.CustomerAdress = Console.ReadLine();
                            myO.OrderDate = Console.ReadLine();
                            myO.ShipDate= Console.ReadLine();
                            myO.DeliveryrDate= Console.ReadLine();
                            //Console.WriteLine(//קריאה לפונקצית הוספה);
                            break;
                        case 2:
                            Console.WriteLine("Enter ID of the order to delete:");
                            choice= Console.Read();
                            //לשלוח למחיקה
                            break;
                        case 3:
                            Console.WriteLine("Enter the details of the order to update:");
                            Order myO2 = new Order();
                            myO2.CustomerName =Console.ReadLine();
                            myO2.CustomerEmail = Console.ReadLine();
                            myO2.CustomerAdress = Console.ReadLine();
                            myO2.OrderDate = Console.ReadLine();
                            myO2.ShipDate = Console.ReadLine();
                            myO2.DeliveryrDate = Console.ReadLine();
                            //לשלוח לעידכון
                            break;
                        case 4:
                            Console.WriteLine("Enter the ID of the order to get:");
                            int ID3;
                            ID3 = Console.Read();
                            //לקרוא לטו סטרינג
                            //לשלוח לגט
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter your choice:");
                    Console.WriteLine("1 to add an order item");
                    Console.WriteLine("2 to delete an order item");
                    Console.WriteLine("3 to update an order item");
                    Console.WriteLine("4 to get an order item");
                    Console.WriteLine("5 to get all the order items");
                    choice = Console.Read();
                    switch(choice)
                    {
                        case 1:
                            Console.WriteLine("Enter details of the order item to add:");
                            OrderItem myO = new OrderItem();
                            myO.ProductId = Console.Read();
                            myO.OrderId = Console.Read();
                            myO.Price = Console.Read();
                            myO.Amount = Console.Read();
                            //Console.WriteLine(//קריאה לפונקצית הוספה);
                            break;
                        case 2:
                            Console.WriteLine("Enter ID of the order item to delete:");
                            choice = Console.Read();
                            //לשלוח למחיקה
                            break;
                        case 3:
                            Console.WriteLine("Enter the details of the order item to update:");
                            OrderItem myO2 = new OrderItem();
                            myO2.ProductId = Console.Read();
                            myO2.OrderId = Console.Read();
                            myO2.Price = Console.Read();
                            myO2.Amount = Console.Read();
                            //לשלוח לעידכון
                            break;
                        case 4:
                            Console.WriteLine("Enter the ID of the order item to get:");
                            int ID3;
                            ID3 = Console.Read();
                            //לקרוא לטו סטרינג
                            //לשלוח לגט
                            break;
                        case 5:
                            //להפעיל את גט אול
                            //להדפיס עי פור איטש את המערך שהוחזר
                            break;
                    }
                    break;
            }
            
        } while (choice != 0);
    }
}




    
   




