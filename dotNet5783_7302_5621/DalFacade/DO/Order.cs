//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace DO;

public struct Order

{
    int Id;
    void setId(int i) { Id = i; }
    int getId() { return Id; }

    string CustomerName;
    void setCustomerName(string c) { CustomerName = c; }
    string getCustomerName() { return CustomerName; }

    string Mail;
    void setMail(string m) { Mail = m; }
    string getMail() { return Mail; }

    string Adress;
    void setAdress(string a) { Adress = a; }
    string getAdress() { return Adress; }

    DateTime CreatingOrder;
    void setCreatingOrder(DateTime d) { CreatingOrder =d ; }
    DateTime getCreatingOrder() { return CreatingOrder; }

    DateTime OrderTime;
    void setOrderTime(DateTime d) { OrderTime = d; }
    DateTime getOrderTime() { return OrderTime; }

    DateTime Delivery;
    void setDelivery(DateTime d) { Delivery = d; }
    DateTime getDelivery() { return Delivery; }


}
