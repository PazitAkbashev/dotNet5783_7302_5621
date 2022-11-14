using System;
namespace Stage0
{
    partial class Program
    {
        static void Main(string[]args)
        {
            Welcome5621();
            Welcome7302();
        }

        static partial void Welcome7302();
        private static void Welcome5621()
        {
            Console.Write("Enter your name: ");
            Console.WriteLine("{0}, welcome to my first console application", Console.ReadLine());
        }
    }
}
