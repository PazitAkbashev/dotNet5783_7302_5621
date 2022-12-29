using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DalApi;


public class DalDoesNoExistException : Exception
{
    public DalDoesNoExistException(string type) : base($"{type} was not found") { }
}


public class DalAlreadyExistsException : Exception
{
    public DalAlreadyExistsException(string type) : base($"{type} already exists") { }
}


public class DalDoesNoExistOrAlreadyShippedException : Exception
{
    public DalDoesNoExistOrAlreadyShippedException(string type) : base($"{type} was not found or order already shipped") { }
}


public class DalDoesNoExistOrAlreadyShippedButDidntSuppliedException : Exception
{
    public DalDoesNoExistOrAlreadyShippedButDidntSuppliedException(string type) : base($"{type} was not found or order already shipped") { }
}

//stage 4
[Serializable]
public class DalConfigException : Exception
{
    public DalConfigException(string msg) : base(msg) { }
    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
}






