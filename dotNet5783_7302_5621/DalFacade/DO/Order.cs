

namespace DO;
using static DO.Enums;

/// <summary>
/// 
/// </summary>
public struct Order

{
    public int ID { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerAdress { get; set; }
    public DateTime OrderDate { get; set; }//יצירת הזמנה
    public DateTime ShipDate { get; set; }//משלוח
    public DateTime DeliveryrDate { get; set; }//מסירה
    public override string ToString() => $@"Order-id={ID}, Customer-name={CustomerName},Mail={CustomerEmail},Adress= {CustomerAdress},CreatingOrder= {OrderDate},OrderTime={DeliveryrDate}, Delivery={ShipDate}";

}
