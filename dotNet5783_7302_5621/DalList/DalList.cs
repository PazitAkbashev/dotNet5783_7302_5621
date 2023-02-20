using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dal;
/// <summary>
/// 
/// </summary>
internal sealed class DalList : IDal
{
    private DalList()
    {
        Order = new DalOrder();
        Product = new DalProduct();
        OrderItem = new DalOrderItem();
    }
    public static IDal Instance { get; } = new DalList();
    public IProduct Product { get; }
    public IOrder Order { get; }
    public IOrderItem OrderItem { get; }
}
