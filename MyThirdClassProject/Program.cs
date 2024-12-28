using System;
using MySecondClassLibrary;

namespace MyThirdClassProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            clsMyMath MyMath = new clsMyMath();

            Console.WriteLine(MyMath.Sum(12, 2));
        }
    }
}
