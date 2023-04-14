using BlImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * using factory design pattern
 */
namespace BlApi
{
    public class Factory
    {
        static public IBl Get => new Bl();
    }
}
