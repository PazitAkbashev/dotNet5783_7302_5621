
namespace DO;
using static DO.Enums;

/// <summary>
/// the order methods
/// Data Object
/// </summary>
public struct Order
{
    public int ID { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerEmail { get; set; }
    public string? CustomerAdress { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public DateTime? DeliveryrDate { get; set; }
    public override string ToString() => $@"Order-id={ID},
                                         Customer-name={CustomerName},
                                         Mail={CustomerEmail},
                                         Adress= {CustomerAdress},
                                         CreatingOrder= {OrderDate},
                                         OrderTime={DeliveryrDate}, 
                                         Delivery={ShipDate}";
    //convert this "to strring" into one global function
}
