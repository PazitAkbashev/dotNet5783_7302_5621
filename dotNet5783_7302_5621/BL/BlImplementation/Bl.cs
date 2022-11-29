using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    public class Bl:BlApi.IBl
    {
        public BlApi.ICart Cart => new Cart();
        public BlApi.IOrder Order => new Order();
        public BlApi.IProduct Product => new Product();
    }
}
