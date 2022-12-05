using System;
using System.Collections.Generic;
using Dal;
using DO;
using System.Collections.Generic;
using static DO.Enums;
using DalApi;
using BlApi;
using BlImplementation;

void productFunction()
{
    IBl blProduct = new Bl();
    Console.WriteLine("Please enter your choice:");
    Console.WriteLine("0 to Exit");
    Console.WriteLine("1 to get the products list");
    Console.WriteLine("2 to get product details (for manager");
    Console.WriteLine("3 to get product details (for customer)");
    Console.WriteLine("4 to add a product");
    Console.WriteLine("5 to delete a product");
    Console.WriteLine("6 to update product's details");
    int choice= int.Parse(Console.ReadLine()); ;
    switch (choice)
    {
        case 0:
            return;
        case 1:
            IEnumerable<BO.ProductForList> productList = blProduct.Product.getProductList();
            foreach(var item in productList)
            {
               
            }

            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            break;
        case 5:
            break;
        case 6:
            break;
        default:
            break;
    }
}
void orderFunction()
{
    IBl blProduct = new Bl();
    Console.WriteLine("Please enter your choice:");
    Console.WriteLine("0 to Exit");
    Console.WriteLine("1 to get the orders list");
    Console.WriteLine("2 to get order details");
    Console.WriteLine("3 to update shipping date");
    Console.WriteLine("4 to update delivery date");
    Console.WriteLine("5 to follow your order");
    int choice = int.Parse(Console.ReadLine()); ;
    switch (choice)
    {
        case 0:
            return;
        case 1:
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            break;
        case 5:
            break;
        default:
            break;
    }
}
void cartFunction()
{
    IBl blProduct = new Bl();
    Console.WriteLine("Please enter your choice:");
    Console.WriteLine("0 to Exit");
    Console.WriteLine("1 to add a product to the cart");
    Console.WriteLine("2 to update the amount of product in the cart");
    Console.WriteLine("3 to confirm the cart");
    int choice = int.Parse(Console.ReadLine()); ;
    switch (choice)
    {
        case 0:
            return;
        case 1:
            break;
        case 2:
            break;
        case 3:
            break;
        default:
            break;
    }
}
int choice;
do
{
    Console.WriteLine("Please enter your choice:");
    Console.WriteLine("0 to Exit");
    Console.WriteLine("1 to Product");
    Console.WriteLine("2 to Order");
    Console.WriteLine("3 to Cart");
    choice = int.Parse(Console.ReadLine());
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
