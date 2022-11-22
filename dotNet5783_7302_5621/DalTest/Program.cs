using Dal;
using DO;
using System.Collections.Generic;
using static DO.Enums;


public class Program
{
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
                    DalProduct dalProduct = new DalProduct();
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
                            Console.WriteLine($"The product ID is:{dalProduct.Add(myP)}");
                            break;
                        case 2:
                            Console.WriteLine("Enter the ID of the product to delete:");
                           int ID= Console.Read();
                            dalProduct.Delete(ID);
                            break;
                        case 3:
                            Console.WriteLine("Enter the details of the product to update:");
                            Product myP2 = new Product();
                            myP2.Name = Console.ReadLine();
                            myP2.Category = (Category)int.Parse(Console.ReadLine());
                            myP2.Price = Console.Read();
                            dalProduct.Update(myP2);
                            break;
                        case 4:
                            Console.WriteLine("Enter the ID of the product to get:");
                            int ID2;
                            ID2 = Console.Read();
                            Console.WriteLine(dalProduct.Get(ID2));
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    DalOrder dalOrder=new DalOrder();
                    TimeSpan OrderToShip = new(5, 0, 0, 0);
                    TimeSpan ShipToDelivery = new(4, 0, 0, 0);
                    Console.WriteLine("Enter your choice:");
                    Console.WriteLine("1 to add an order");
                    Console.WriteLine("2 to delete an order");
                    Console.WriteLine("3 to update an order");
                    Console.WriteLine("4 to get an order");
                    choice = Console.Read();
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter details of the order to add:");
                            Order myO = new Order();
                            myO.CustomerName = Console.ReadLine();
                            myO.CustomerEmail = Console.ReadLine();
                            myO.CustomerAdress = Console.ReadLine();
                            myO.OrderDate = DateTime.Now;
                            myO.ShipDate= myO.OrderDate.Add(OrderToShip);
                            myO.DeliveryrDate= myO.ShipDate.Add(ShipToDelivery);
                            Console.WriteLine($"The order ID is:{dalOrder.Add(myO)}");
                            break;
                        case 2:
                            Console.WriteLine("Enter ID of the order to delete:");
                            int ID3= Console.Read();
                            dalOrder.Delete(choice);
                            break;
                        case 3:
                            Console.WriteLine("Enter the details of the order to update:");
                            Order myO2 = new Order();
                            myO2.CustomerName =Console.ReadLine();
                            myO2.CustomerEmail = Console.ReadLine();
                            myO2.CustomerAdress = Console.ReadLine();
                            myO2.OrderDate = DateTime.Now;
                            myO2.ShipDate = myO2.OrderDate.Add(OrderToShip);
                            myO2.DeliveryrDate = myO2.ShipDate.Add(ShipToDelivery);
                            dalOrder.Update(myO2);
                            break;
                        case 4:
                            Console.WriteLine("Enter the ID of the order to get:");
                            int ID4 = Console.Read();
                            Console.WriteLine(dalOrder.Get(ID4));
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    DalOrderItem dalOrderItem = new DalOrderItem();
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
                            OrderItem myOI = new OrderItem();
                            myOI.ProductId = Console.Read();
                            myOI.OrderId = Console.Read();
                            myOI.Price = Console.Read();
                            myOI.Amount = Console.Read();
                            Console.WriteLine($"The order ID is:{dalOrderItem.Add(myOI)}");
                            break;
                        case 2:
                            Console.WriteLine("Enter ID of the order item to delete:");
                            int ID5 = Console.Read();
                            dalOrderItem.Delete(ID5);
                            break;
                        case 3:
                            Console.WriteLine("Enter the details of the order item to update:");
                            OrderItem myOI2 = new OrderItem();
                            myOI2.ProductId = Console.Read();
                            myOI2.OrderId = Console.Read();
                            myOI2.Price = Console.Read();
                            myOI2.Amount = Console.Read();
                            dalOrderItem.Update(myOI2);
                            break;
                        case 4:
                            Console.WriteLine("Enter the ID of the order item to get:");
                            int ID6;
                            ID6 = Console.Read();
                            Console.WriteLine(dalOrderItem.Get(ID6));

                            break;
                        case 5:
                            IEnumerable<OrderItem> orderItems = new List<OrderItem>();
                            orderItems = dalOrderItem.GetAll();
                            foreach (OrderItem orderItem in orderItems)
                            {
                                Console.WriteLine(orderItem);
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            
        } while (choice != 0);
    }
}




    
   




