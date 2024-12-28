using System;
using MyFirstClassLibrary;


namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            clsMyMath myMath = new clsMyMath();
            Console.WriteLine(myMath.Sum(20, 50, 70));
            Console.WriteLine("Hello, World!");
        }
    }
}
