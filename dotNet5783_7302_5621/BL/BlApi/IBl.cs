using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    /// <summary>
    /// the main BL interface
    /// </summary>
    public interface IBL
    {
        IOrder Order { get; }
        IProduct Product { get;}
        ICart cart { get; }
    }
}
