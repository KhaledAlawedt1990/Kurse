
using MyNameSpace;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading.Tasks.Dataflow;

namespace MyNameSpace
{
    public class myClass
    {
        public int Property1 { get; set; }
        public void Methode1()
        {
            Console.WriteLine("\tMethode1 is executed without Parameters.");
        }
        public void Methode2(int Value1, string Value2)
        {
            Console.WriteLine($"\tMethode2 is executed with Parameters {Value1} and {Value2} ");
        }
    }
}

public class Program
{
    static void Main(string[] args)

    {
        //Get the type information for myClass
        Type MyClassType = typeof(myClass);

        //Get and display information about this myClass
        Console.WriteLine($"\n\tName: {MyClassType.Name}");
        Console.WriteLine($"\tFullname: {MyClassType.FullName}");

        //Get the Propereties about myClass
        Console.WriteLine("\n\tPropereties");
        
        foreach(var property in MyClassType.GetProperties())
        {
            Console.WriteLine($"\tProperty Name: {property.Name} ,  Property Type: {property.PropertyType} ");
        }

        //Get the methods of myClass
        Console.WriteLine("\n\tMethods");
        foreach(var methode in MyClassType.GetMethods())
        {
            Console.WriteLine($"\tMehtode Type: {methode.ReturnType} {methode.Name} ({GetParameterList(methode.GetParameters())})");
        }

        //Create an Insatnce of myClass
        object myClassInstance = Activator.CreateInstance(MyClassType);

        //set the Value property1 using reflection
        MyClassType.GetProperty("Property1").SetValue(myClassInstance, 50);
        Console.WriteLine("\n\t Set property1 to 50 Using Reflection");

        //Get the value of Property using Reflection
        Console.WriteLine("\n\tGetting Property Value Using Reflection.");
        int Property1Value = (int)MyClassType.GetProperty("Property1").GetValue(myClassInstance);
        Console.WriteLine($"\tProperty1 Value is {Property1Value}");

        //Now how to execute methods Using Reflection.
        Console.WriteLine("\n\tExecuting Methode Using Reflection\n");

        //Invoke the Mehtode using reflection
        MyClassType.GetMethod("Methode1").Invoke(myClassInstance, null);

        //Invoke the Mehtode using reflection with parameters
        object[] parameters = { 200, "Khaled Alawedat" };
        MyClassType.GetMethod("Methode2").Invoke(myClassInstance, parameters);

        Console.ReadLine();
    }

    public static string GetParameterList(ParameterInfo[] parameter)
    {
        return string.Join(", " ,parameter.Select(parameter => $"{parameter.ParameterType}"));
    }
}


