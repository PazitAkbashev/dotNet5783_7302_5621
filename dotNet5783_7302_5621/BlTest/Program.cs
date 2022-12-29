using System;
using System.Collections.Generic;
using Dal;
using System.Collections.Generic;
using DalApi;
using BlApi;
using BlImplementation;
using BO;
 ///the BL main program


///the product function
void productFunction()
{
    BlApi.IBl? blProduct = BlApi.Factory.Get();
    Console.WriteLine("Please enter your choice:");
    Console.WriteLine("0 to Exit");
    Console.WriteLine("1 to get the products list");
    Console.WriteLine("2 to get product details (for manager");
    Console.WriteLine("3 to get product details (for customer)");
    Console.WriteLine("4 to add a product");
    Console.WriteLine("5 to delete a product");
    Console.WriteLine("6 to update product's details");
    int choice= int.Parse(Console.ReadLine()!); 
    switch (choice)
    {
        case 0:
            return;
        case 1:
            try
            {
                IEnumerable<BO.ProductForList> productList = blProduct.Product.getProductList();
                foreach (var item in productList)
                {
                    Console.WriteLine("id: {0} name: {1} price: {2} category:{3}", item.ID, item.Name, item.Price, item.category);
                }
            }
            catch (BO.BoDoesNotExist ex)
            {
                Console.WriteLine("BoDoesNotExist "+ex);
            } 
            break;
        case 2:
            try
            {
                Console.WriteLine("enter id of the product to get :");
                int myId = int.Parse(Console.ReadLine()!);
                BO.Product product = blProduct.Product.getProductDetailsD(myId);
                Console.WriteLine("id: {0} name: {1} price: {2} category: {3} in stock: {4}", product.ID, product.Name, product.Price, product.category, product.InStock);
            }
            catch (BO.BoDoesNotExist ex)
            {
                Console.WriteLine("BoDoesNotExist " + ex);
            }
            break;
        case 3:
            try
            {
                Console.WriteLine("enter id of the product to get and your cart details(name, email, address, list of items, total price:");
                int myId2 = int.Parse(Console.ReadLine()!);
                BO.Cart cart = new BO.Cart();
                cart.CustomerName = Console.ReadLine();
                cart.CustomerEmail = Console.ReadLine();
                cart.CustomerAddress = Console.ReadLine();
                List<BO.OrderItem> myItems = new List<BO.OrderItem>();
                foreach (var item in myItems)
                {
                    BO.OrderItem tempOrderItem = new BO.OrderItem();
                    tempOrderItem.ID = int.Parse(Console.ReadLine()!);
                    tempOrderItem.ProductName = Console.ReadLine();
                    tempOrderItem.ProductID = int.Parse(Console.ReadLine()!);
                    tempOrderItem.Price = double.Parse(Console.ReadLine()!);
                    tempOrderItem.Amount = int.Parse(Console.ReadLine()!);
                    tempOrderItem.TotalPrice = double.Parse(Console.ReadLine()!);
                    myItems.Add(tempOrderItem);
                }
                cart.Items = myItems;
                cart.TotalPrice = double.Parse(Console.ReadLine()!);
                BO.ProductItem productItem = blProduct.Product.getProductDetailsC(myId2, cart);
            }
            catch (BO.BoDoesNotExist ex)
            {
                Console.WriteLine("BoDoesNotExist " + ex);
            }
            break;
        case 4:
            try
            {
                Console.WriteLine("enter details of the product to add(id,name,price,category,in stock");
                BO.Product myProduct = new BO.Product();
                myProduct.ID = int.Parse(Console.ReadLine()!);
                myProduct.Name = Console.ReadLine();
                myProduct.Price = double.Parse(Console.ReadLine()!);
                string cat = Console.ReadLine()!;
                myProduct.category = (BO.Enums.category)Enum.Parse(typeof(BO.Enums.category?), cat);
                myProduct.InStock = int.Parse(Console.ReadLine()!);
                blProduct.Product.addProduct(myProduct);
            }
            catch (BO.BoAlreadyExist ex)
            {
                Console.WriteLine("BoAlreadyExist " + ex);
            }
            break;
        case 5:
            try
            {
                Console.WriteLine("enter id of the product to delete:");
                int myId3 = int.Parse(Console.ReadLine()!);
                blProduct.Product.deleteProduct(myId3);
            }
            catch (BO.BoAlreadyExist ex)
            {
                Console.WriteLine("BoAlreadyExist " + ex);
            }
            break;
        case 6:
            try
            {
                Console.WriteLine("enter details of the product to update(id,name,price,category,in stock");
                BO.Product myProduct2 = new BO.Product();
                myProduct2.ID = int.Parse(Console.ReadLine()!);
                myProduct2.Name = Console.ReadLine();
                myProduct2.Price = double.Parse(Console.ReadLine()!);
                string cat2 = Console.ReadLine()!;
                myProduct2.category = (BO.Enums.category)Enum.Parse(typeof(BO.Enums.category?), cat2);
                myProduct2.InStock = int.Parse(Console.ReadLine()!);
                myProduct2.InStock = int.Parse(Console.ReadLine()!);
                blProduct.Product.updateProduct(myProduct2);
            }
            catch (BO.BoDoesNotExist ex)
            {
                Console.WriteLine("BoDoesNotExist " + ex);
            }
            break;
        default:
            break;
    }
}

///the order function
void orderFunction()
{
    BlApi.IBl? blOrder = BlApi.Factory.Get();
    Console.WriteLine("Please enter your choice:");
    Console.WriteLine("0 to Exit");
    Console.WriteLine("1 to get the orders list");
    Console.WriteLine("2 to get order details");
    Console.WriteLine("3 to update shipping date");
    Console.WriteLine("4 to update delivery date");
    Console.WriteLine("5 to follow your order");
    int choice = int.Parse(Console.ReadLine()!); 
    switch (choice)
    {
        case 0:
            return;
        case 1:
            try
            {
                IEnumerable<BO.OrderForList> orderList = blOrder.Order.getOrderList();
                foreach (var item in orderList)
                {
                    Console.WriteLine("id: {0} name: {1} status: {2} amount of items: {3} total price: {4}", item.ID, item.CustomerName, item.Status, item.AmountOfItems, item.TotalPrice);
                }
            }
            catch (BO.BoDoesNotExist ex)
            {
                Console.WriteLine("BoDoesNotExist " + ex);
            }
            break;
        case 2:
            try
            {
                Console.WriteLine("enter id of the order to get:");
                int myId4 = int.Parse(Console.ReadLine()!);
                BO.Order order = blOrder.Order.getOrderDetails(myId4);
                Console.WriteLine("id: {0} name: {1} email: {2} address: {3} status: {4} order date: {5} ship date: {6} delivery date: {7}", order.ID, order.CustomerName, order.CustomerEmail, order.CustomerAddress, order.Status, order.OrderDate, order.ShipDate, order.DeliveryrDate);
                foreach (var item in order.Items!)
                {
                    Console.WriteLine("id: {0} name: {1} product id: {2} price: {3} amount: {4} total price: {5}", item.ID, item.ProductName, item.ProductID, item.Price, item.Amount, item.TotalPrice);
                }
                Console.WriteLine("total price: {0}", order.TotalPrice);
            }
            catch (BO.BoDoesNotExist ex)
            {
                Console.WriteLine("BoDoesNotExist " + ex);
            }
            break;
        case 3:
            try
            {
                Console.WriteLine("enter id of the order to update:");
                int myId5 = int.Parse(Console.ReadLine()!);
                BO.Order order2 = blOrder.Order.updateOrderShipping(myId5);
                Console.WriteLine("id: {0} name: {1} email: {2} address: {3} status: {4} order date: {5} ship date: {6} delivery date: {7}", order2.ID, order2.CustomerName, order2.CustomerEmail, order2.CustomerAddress, order2.Status, order2.OrderDate, order2.ShipDate, order2.DeliveryrDate);
                foreach (var item in order2.Items!)
                {
                    Console.WriteLine("id: {0} name: {1} product id: {2} price: {3} amount: {4} total price: {5}", item.ID, item.ProductName, item.ProductID, item.Price, item.Amount, item.TotalPrice);
                }
                Console.WriteLine("total price: {0}", order2.TotalPrice);
            }
            catch (BO.BoDoesNotExist ex)
            {
                Console.WriteLine("BoDoesNotExist " + ex);
            }
            break;
        case 4:
            try
            {
                Console.WriteLine("enter id of the order to update:");
                int myId6 = int.Parse(Console.ReadLine()!);
                BO.Order order3 = blOrder.Order.updateOrderSupply(myId6);
                Console.WriteLine("id: {0} name: {1} email: {2} address: {3} status: {4} order date: {5} ship date: {6} delivery date: {7}", order3.ID, order3.CustomerName, order3.CustomerEmail, order3.CustomerAddress, order3.Status, order3.OrderDate, order3.ShipDate, order3.DeliveryrDate);
                foreach (var item in order3.Items!)
                {
                    Console.WriteLine("id: {0} name: {1} product id: {2} price: {3} amount: {4} total price: {5}", item.ID, item.ProductName, item.ProductID, item.Price, item.Amount, item.TotalPrice);
                }
                Console.WriteLine("total price: {0}", order3.TotalPrice);
            }
            catch (BO.BoDoesNotExist ex)
            {
                Console.WriteLine("BoDoesNotExist " + ex);
            }
            break;
        case 5:
            try
            {
                Console.WriteLine("enter id of the order to follow: {0}");
                int myId7 = int.Parse(Console.ReadLine()!);
                BO.OrderTracking orderTracking = blOrder.Order.getOrderTracking(myId7);
                Console.WriteLine("id: {0} status: {1}", orderTracking.ID, orderTracking.Status);
            }
            catch (BO.BoDoesNotExist ex)
            {
                Console.WriteLine("BoDoesNotExist " + ex);
            }
            break;
        default:
            break;
    }
}

///the cart function
void cartFunction()
{
    BlApi.IBl? blCart = BlApi.Factory.Get();
    Console.WriteLine("Please enter your choice:");
    Console.WriteLine("0 to Exit");
    Console.WriteLine("1 to add a product to the cart");
    Console.WriteLine("2 to update the amount of product in the cart");
    Console.WriteLine("3 to confirm the cart");
    int choice = int.Parse(Console.ReadLine()!); 
    switch (choice)
    {
        case 0:
            return;
        case 1:
            try
            {
                Console.WriteLine("enter id of the product to add and your cart details(name, email, address, list of items, total price:");
                int myId = int.Parse(Console.ReadLine()!);
                BO.Cart cart = new BO.Cart();
                cart.CustomerName = Console.ReadLine();
                cart.CustomerEmail = Console.ReadLine();
                cart.CustomerAddress = Console.ReadLine();
                List<BO.OrderItem> myItems = new List<BO.OrderItem>();
                foreach (var item in myItems)
                {
                    BO.OrderItem tempOrderItem = new BO.OrderItem();
                    tempOrderItem.ID = int.Parse(Console.ReadLine()!);
                    tempOrderItem.ProductName = Console.ReadLine();
                    tempOrderItem.ProductID = int.Parse(Console.ReadLine()!);
                    tempOrderItem.Price = double.Parse(Console.ReadLine()!);
                    tempOrderItem.Amount = int.Parse(Console.ReadLine()!);
                    tempOrderItem.TotalPrice = double.Parse(Console.ReadLine()!);
                    myItems.Add(tempOrderItem);
                }
                cart.Items = myItems;
                cart.TotalPrice = double.Parse(Console.ReadLine()!);
                BO.Cart myCart = blCart.Cart.addProductToCart(cart, myId);
                Console.WriteLine("name: {0} email: {1} address: {2}", myCart.CustomerName, myCart.CustomerEmail, myCart.CustomerAddress);
                foreach (var item in myCart.Items!)
                {
                    Console.WriteLine("id: {0} product name: {1} product id: {2} price: {3} amount: {4} total price: {5}", item.ID, item.ProductName, item.ProductID, item.Price, item.Amount, item.TotalPrice);
                }
                Console.WriteLine("total price: {0}", myCart.TotalPrice);
            }
            catch (BO.BoDoesNotExist ex)
            {
                Console.WriteLine("BoDoesNotExist " + ex);
            }
            break;
        case 2:
            try
            {
                Console.WriteLine("enter the product id, your cart details, and new amount:");
                int myId2 = int.Parse(Console.ReadLine()!);
                BO.Cart cart2 = new BO.Cart();
                cart2.CustomerName = Console.ReadLine();
                cart2.CustomerEmail = Console.ReadLine();
                cart2.CustomerAddress = Console.ReadLine();
                List<BO.OrderItem> myItems2 = new List<BO.OrderItem>();
                foreach (var item in myItems2)
                {
                    BO.OrderItem tempOrderItem = new BO.OrderItem();
                    tempOrderItem.ID = int.Parse(Console.ReadLine()!);
                    tempOrderItem.ProductName = Console.ReadLine();
                    tempOrderItem.ProductID = int.Parse(Console.ReadLine()!);
                    tempOrderItem.Price = double.Parse(Console.ReadLine()!);
                    tempOrderItem.Amount = int.Parse(Console.ReadLine()!);
                    tempOrderItem.TotalPrice = double.Parse(Console.ReadLine()!);
                    myItems2.Add(tempOrderItem);
                }
                cart2.Items = myItems2;
                cart2.TotalPrice = double.Parse(Console.ReadLine()!);
                int newAmount = int.Parse(Console.ReadLine()!);
                BO.Cart cart3 = blCart.Cart.updateAmountOfProduct(cart2, myId2, newAmount);
                Console.WriteLine("name: {0} email: {1} address: {2}", cart3.CustomerName, cart3.CustomerEmail, cart3.CustomerAddress);
                foreach (var item in cart3.Items!)
                {
                    Console.WriteLine("id: {0} product name: {1} product id: {2} price: {3} amount: {4} total price: {5}", item.ID, item.ProductName, item.ProductID, item.Price, item.Amount, item.TotalPrice);
                }
                Console.WriteLine("total price: {0}", cart3.TotalPrice);
            }
            catch (BO.BoDoesNotExist ex)
            {
                Console.WriteLine("BoDoesNotExist " + ex);
            }
            break;
        case 3:
            try
            {
                Console.WriteLine("enter your cart details:");
                BO.Cart cart4 = new BO.Cart();
                cart4.CustomerName = Console.ReadLine();
                cart4.CustomerEmail = Console.ReadLine();
                cart4.CustomerAddress = Console.ReadLine();
                List<BO.OrderItem> myItems4 = new List<BO.OrderItem>();
                foreach (var item in myItems4)
                {
                    BO.OrderItem tempOrderItem = new BO.OrderItem();
                    tempOrderItem.ID = int.Parse(Console.ReadLine()!);
                    tempOrderItem.ProductName = Console.ReadLine();
                    tempOrderItem.ProductID = int.Parse(Console.ReadLine()!);
                    tempOrderItem.Price = double.Parse(Console.ReadLine()!);
                    tempOrderItem.Amount = int.Parse(Console.ReadLine()!);
                    tempOrderItem.TotalPrice = double.Parse(Console.ReadLine()!);
                    myItems4.Add(tempOrderItem);
                }
                cart4.Items = myItems4;
                cart4.TotalPrice = double.Parse(Console.ReadLine()!);
                blCart.Cart.confirmCart(cart4);
            }
            catch (BO.BoDoesNotExist ex)
            {
                Console.WriteLine("BoDoesNotExist " + ex);
            }
            break;
        default:
            break;
    }
}


///the main
int choice;
do
{
    Console.WriteLine("Please enter your choice:");
    Console.WriteLine("0 to Exit");
    Console.WriteLine("1 to Product");
    Console.WriteLine("2 to Order");
    Console.WriteLine("3 to Cart");
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
            cartFunction();
            break;
        default:
            break;
    }
} while (choice != 0);
