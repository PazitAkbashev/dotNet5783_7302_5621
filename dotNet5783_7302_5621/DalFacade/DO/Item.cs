//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace DO; //parit

public struct Item
{
    int UniqueId;
    void setUniqueId(int u) { UniqueId = u; }
    int getUniqueId() { return UniqueId; }

    int OrderId;
    void setOrderId(int o) { OrderId = o; }
    int getOrderId() { return OrderId; }

    int ProductId;
    void setProductId(int p) { ProductId = p; }
    int getProductId() { return ProductId; }

    double Price;
    void setPrice(double p) { Price = p; }
    double getPrice() { return Price; }

    int Amount;
    void setAmount(int a) { Amount = a; }
    int getAmount() { return Amount; }

}
