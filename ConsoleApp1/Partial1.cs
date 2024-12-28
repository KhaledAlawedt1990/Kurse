using System;

public partial class MyClass
{
    public int age { get; set; }

    public partial void PrintAge();

    public void Birthday()
    {
        age++;
        PrintAge();
    }
    public void Method1()
    {
        Console.WriteLine("Methode 1 is called here");
    }
}
