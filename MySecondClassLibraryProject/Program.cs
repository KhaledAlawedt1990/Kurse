using MySecondClassLibrary;
using System;


namespace MySecondClassLibraryProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            clsMyMath myMath = new clsMyMath();
           Console.WriteLine( myMath.Multiply(10, 2));
            Console.WriteLine(myMath.Multiply(10, 2,3));
            Console.WriteLine(myMath.Multiply(10, 2,3,4));
            Console.WriteLine(myMath.Sum(10, 20));
            Console.WriteLine("Hallo");
        }
    }
}
