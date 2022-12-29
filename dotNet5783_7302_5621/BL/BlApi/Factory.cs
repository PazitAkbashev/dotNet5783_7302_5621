using BlImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public class Factory
    {
        static public IBl Get()
        {
            Bl bl = new Bl();
            return bl;
        }

    }

}
