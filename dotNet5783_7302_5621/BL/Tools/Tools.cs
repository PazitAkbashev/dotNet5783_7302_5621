using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace Tools
{
    /// <summary>
    /// Extension functions for the exceptions
    /// </summary>
    public static class Tools
    {
        public static void negativeNumber(this int num)
        {
            if (num <= 0)
                throw new BO.negativeNum("the number is negative");
        }

        public static void notNull(this string str)
        {
            if (str==null)
                throw new BO.nullStr("the string is null");
        }

        public static void negativeDoubleNum(this double num)
        {
            if (num <= 0)
                throw new BO.negativeDNum("the number is negative");
        }

        public static void equalsNumbers(this int num,int num2)
        {
            if (num == num2)
                throw new BO.theSameNumbers("the number is negative");
        }

        public static void inStockSmallerThanAmount(this int num, int num2)
        {
            if (num < num2)
                throw new BO.notEnoughProducts("their are not enough products in stock");
        }
    }
}
