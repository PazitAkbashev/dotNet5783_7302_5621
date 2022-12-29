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
        public IBl Get()
        {
            BlApi.IBl bl = new Bl();
          //  Bl bl = new Bl();
            return bl;
        }

    }

}
