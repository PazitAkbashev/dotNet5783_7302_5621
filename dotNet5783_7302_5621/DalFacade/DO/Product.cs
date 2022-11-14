//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace DO;  //motzar

public struct Product
{
    int Id;
    void setId(int i) { Id = i; }
    int getId() { return Id; }

    string Name;
    enum Catagory { };
    double Price;
    void setPrice(double p) { Price = p; }
    double getPrice() { return Price; }

    int Amount;
    void setAmount(int a) { Amount = a; }
    int getAmount() { return Amount; }

}
