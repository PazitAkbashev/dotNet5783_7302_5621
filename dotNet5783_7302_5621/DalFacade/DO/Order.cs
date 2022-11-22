

namespace DO;
using static DO.Enums;

public struct Order

{
    public int ID { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerAdress { get; set; }
    public DateTime OrderDate { get; set; } /*= DateTime.MinValue;*/ //יצירת הזמנה
    public DateTime ShipDate { get; set; } /*= DateTime.MinValue;*///משלוח
    public DateTime DeliveryrDate { get; set; } /*= DateTime.MinValue;*///מסירה
    public override string ToString() => $@"Order-id={ID}, Customer-name={CustomerName},Mail={CustomerEmail},Adress= {CustomerAdress},CreatingOrder= {OrderDate},OrderTime={DeliveryrDate}, Delivery={ShipDate}";

}
