using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BlApi;
/// <summary>
/// the main interface
/// </summary>
public interface IBl
{
        public ICart Cart { get; }
        public IOrder Order { get; }
        public IProduct Product { get; }
}


