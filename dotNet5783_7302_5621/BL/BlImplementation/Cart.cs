using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
using DalApi;

namespace BlImplementation;

internal class Cart :ICart
{
    private IDal dalCart = new Dal.DalList();

}
