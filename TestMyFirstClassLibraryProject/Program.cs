
using System;
using MyFirstClassLibrary;


internal class Program
    {
        static void Main(string[] args)
        {

        clsMyMath MyMath = new clsMyMath();
        Console.WriteLine(MyMath.Sum(10, 20));
        Console.WriteLine(MyMath.Sum(10, 20, 30));
            Console.WriteLine("Hello, World!");
        }
    }

