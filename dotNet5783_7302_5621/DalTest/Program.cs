using Dal;
using DO;
using System.Collections.Generic;
using static DO.Enums;
using DalApi;

///the main DO program


///the product function
void productFunction()
{
    try
    {
        IDal dalProduct = new Dal.DalList();
        Console.WriteLine("Enter your choice:");
        Console.WriteLine("1 to add a product");
        Console.WriteLine("2 to delete a product");
        Console.WriteLine("3 to update a product");
        Console.WriteLine("4 to get a product");
        int choice = (int.Parse(Console.ReadLine()!));
        switch (choice)
        {
            case 1:
                Console.WriteLine("for adding a product please enter the folowing: name,price,category(0-9),how many in stock:");
                Product myP = new Product();
                myP.Name = Console.ReadLine()!;
                myP.Price = double.Parse(Console.ReadLine()!);
                myP.Category = (Category)int.Parse(Console.ReadLine()!);
                myP.inStock = int.Parse(Console.ReadLine()!);
                Console.WriteLine($"The product ID is:{dalProduct.Product.Add(myP)}");
                break;
            case 2:
                Console.WriteLine("Enter the ID of the product to delete:");
                int ID = int.Parse(Console.ReadLine()!);
                dalProduct.Product.Delete(ID);
                break;
            case 3:
                Console.WriteLine("Enter the ID of the product you wants to update:");
                int upID = int.Parse(Console.ReadLine()!);
                Console.WriteLine($"the product you wants to update is:{dalProduct.Product.GetSingle(x => x?.ID == upID)}");
                Console.WriteLine("for the new product, enter the folowing: name,price,category(0-9),how many in stock:");
                Product myP2 = new Product();
                myP2.Name = Console.ReadLine()!;
                myP2.Price = int.Parse(Console.ReadLine()!);
                myP2.Category = (Category)int.Parse(Console.ReadLine()!);
                myP2.inStock= int.Parse(Console.ReadLine()!);
                dalProduct.Product.Update(myP2);
                break;
            case 4:
                Console.WriteLine("Enter the ID of the product to get:");
                int ID2;
                ID2 = int.Parse(Console.ReadLine()!);
                Console.WriteLine(dalProduct.Product.GetSingle(x => x?.ID == ID2));
                break;
            default:
                break;
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex);
    }
}

///the order function
void orderFunction()
{
    try
    {
        IDal dalOrder = new Dal.DalList();
        TimeSpan OrderToShip = new(5, 0, 0, 0);
        TimeSpan ShipToDelivery = new(4, 0, 0, 0);
        Console.WriteLine("Enter your choice:");
        Console.WriteLine("1 to add an order");
        Console.WriteLine("2 to delete an order");
        Console.WriteLine("3 to update an order");
        Console.WriteLine("4 to get an order");
        int choice = int.Parse(Console.ReadLine()!);
        switch (choice)
        {
            case 1:
                Console.WriteLine("for adding an order please enter the folowing: name, email, address:");
                Order myO = new Order();
                myO.CustomerName = Console.ReadLine()!;
                myO.CustomerEmail = Console.ReadLine()!;
                myO.CustomerAdress = Console.ReadLine()!;
                myO.OrderDate = DateTime.Now;
                myO.ShipDate = myO.OrderDate?.Add(OrderToShip);
                myO.DeliveryrDate = myO.ShipDate?.Add(ShipToDelivery);
                Console.WriteLine($"Your order ID is:{dalOrder.Order.Add(myO)}");
                break;
            case 2:
                Console.WriteLine("Enter ID of the order to delete:");
                int ID3 = int.Parse(Console.ReadLine()!);
                dalOrder.Order.Delete(choice);
                break;
            case 3:
                Console.WriteLine("Enter the ID of the order you wants to update:");
                int upID2 = int.Parse(Console.ReadLine()!);
                Console.WriteLine($"the order you wants to update is:{dalOrder.Order.GetSingle(x => x?.ID == upID2)}");
                Console.WriteLine("for the new order, enter the folowing: customer-name,customer-email,customer-adress,order-date,ship-date,deliveryr-date:");
                Order myO2 = new Order();
                myO2.CustomerName = Console.ReadLine()!;
                myO2.CustomerEmail = Console.ReadLine()!;
                myO2.CustomerAdress = Console.ReadLine()!;
                myO2.OrderDate = DateTime.Now;
                myO2.ShipDate = myO2.OrderDate?.Add(OrderToShip);
                myO2.DeliveryrDate = myO2.ShipDate?.Add(ShipToDelivery);
                dalOrder.Order.Update(myO2);
                break;
            case 4:
                Console.WriteLine("Enter the ID of the order to get:");
                int ID4 = int.Parse(Console.ReadLine()!);
                Console.WriteLine(dalOrder.Order.GetSingle(x=>x?.ID==ID4));
                break;
            default:
                break;
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex);
    } 
}


///the order item function
void orderItemFunction()
{
    try
    {
        IDal dalOrderItem = new Dal.DalList();
        Console.WriteLine("Enter your choice:");
        Console.WriteLine("1 to add an order item");
        Console.WriteLine("2 to delete an order item");
        Console.WriteLine("3 to update an order item");
        Console.WriteLine("4 to get an order item");
        Console.WriteLine("5 to get all the order items");
        int choice = int.Parse(Console.ReadLine()!);
        switch (choice)
        {
            case 1:
                Console.WriteLine("for adding an order item please enter the folowing: product id, order id, price, amount:");
                OrderItem myOI = new OrderItem();
                myOI.ProductId = int.Parse(Console.ReadLine()!);
                myOI.OrderId = int.Parse(Console.ReadLine()!);
                myOI.Price = double.Parse(Console.ReadLine()!);
                myOI.Amount = int.Parse(Console.ReadLine()!);
                Console.WriteLine($"The order ID is:{dalOrderItem.OrderItem.Add(myOI)}");
                break;
            case 2:
                Console.WriteLine("Enter ID of the order item to delete:");
                int ID5 = int.Parse(Console.ReadLine()!);
                dalOrderItem.OrderItem.Delete(ID5);
                break;
            case 3:
                Console.WriteLine("Enter the ID of the order item you wants to update:");
                int upID3 = int.Parse(Console.ReadLine()!);
                Console.WriteLine($"the order item you wants to update is:{dalOrderItem.OrderItem.GetSingle(x => x?.ID == upID3)}");
                Console.WriteLine("for the new order item, enter the folowing: product ID, order ID, price, amount:");
                OrderItem myOI2 = new OrderItem();
                myOI2.ProductId = int.Parse(Console.ReadLine()!);
                myOI2.OrderId = int.Parse(Console.ReadLine()!);
                myOI2.Price = int.Parse(Console.ReadLine()!);
                myOI2.Amount = int.Parse(Console.ReadLine()!);
                dalOrderItem.OrderItem.Update(myOI2);
                break;
            case 4:
                Console.WriteLine("Enter the ID of the order item to get:");
                int ID6;
                ID6 = int.Parse(Console.ReadLine()!);
                Console.WriteLine(dalOrderItem.OrderItem.GetSingle(x => x?.ID == ID6));

                break;
            case 5:
                IEnumerable<OrderItem?> orderItems = new List<OrderItem?>();
                orderItems = dalOrderItem.OrderItem.GetAll();
                IEnumerator<OrderItem?> myIE= orderItems.GetEnumerator();
                while(myIE.MoveNext())
                {
                    Console.WriteLine(myIE.Current);
                }
                break;
            default:
                break;
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex);
    }
}
int choice;
do
{
    Console.WriteLine("Please enter your choice:");
    Console.WriteLine("0 to Exit");
    Console.WriteLine("1 to Product");
    Console.WriteLine("2 to Order");
    Console.WriteLine("3 to Order-Item");
    choice = int.Parse(Console.ReadLine()!);

    switch (choice)
    {
        case 0:
            break;
        case 1:
            productFunction();
            break;
        case 2:
            orderFunction();
            break;
        case 3:
            orderItemFunction();
            break;
        default:
            break;
    }
} while (choice != 0);











