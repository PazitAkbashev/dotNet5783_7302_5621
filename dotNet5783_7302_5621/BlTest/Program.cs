using System;
using System.Collections.Generic;
using Dal;
using DO;
using System.Collections.Generic;
using static DO.Enums;
using DalApi;
using BlApi;

void productFunction()
{
    
}
void orderFunction()
{

}
void cartFunction()
{
 
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
