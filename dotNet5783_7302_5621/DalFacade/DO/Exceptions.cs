using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO;

public class wasntFound:Exception
{

    public override string Message=>"The object doesn't exist";
    public override string ToString()
    {
        return Message;
    }
}

public class duplicationID:Exception
{
    public override string Message => "The object already exist";
    public override string ToString()
    {
        return Message;
    }

}


