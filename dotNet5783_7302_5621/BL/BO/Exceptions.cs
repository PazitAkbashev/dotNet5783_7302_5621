using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace BO;


[Serializable]
public class negativeNum : Exception
{
    public negativeNum()
    {
    }

    public negativeNum(string? message) : base(message)
    {
    }

    public negativeNum(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected negativeNum(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}


[Serializable]
public class BoDoesNotExist : Exception
{
    public BoDoesNotExist()
    {
    }

    public BoDoesNotExist(string? message) : base(message)
    {
    }

    public BoDoesNotExist(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected BoDoesNotExist(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}


[Serializable]
public class BoAlreadyExist : Exception
{
    public BoAlreadyExist()
    {
    }

    public BoAlreadyExist(string? message) : base(message)
    {
    }

    public BoAlreadyExist(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected BoAlreadyExist(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

[Serializable]
public class nullStr : Exception
{
    public nullStr()
    {
    }

    public nullStr(string? message) : base(message)
    {
    }

    public nullStr(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected nullStr(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

[Serializable]
public class negativeDNum : Exception
{
    public negativeDNum()
    {
    }

    public negativeDNum(string? message) : base(message)
    {
    }

    public negativeDNum(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected negativeDNum(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

[Serializable]
public class theSameNumbers : Exception
{
    public theSameNumbers()
    {
    }

    public theSameNumbers(string? message) : base(message)
    {
    }

    public theSameNumbers(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected theSameNumbers(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

[Serializable]
public class notEnoughProducts : Exception
{
    public notEnoughProducts()
    {
    }

    public notEnoughProducts(string? message) : base(message)
    {
    }

    public notEnoughProducts(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected notEnoughProducts(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}