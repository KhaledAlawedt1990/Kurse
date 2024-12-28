namespace OOP_Practise
{
    internal class Program
    {

        
            class clsA
            {
                public virtual void Methode1()
                {
                    Console.WriteLine("Here is the Methode1 from Base Class");
                }

                public virtual void Methode2()
                {
                    Console.WriteLine("Here is the Mothode2 from Base Class.");
                }
            }

            class clsB : clsA
            {
                public override void Methode1()
                {
                    Console.WriteLine("Here is the Methode1 from Derived Class");
                }

                public new void Methode2()
                {
                    Console.WriteLine("Here is the Mothode2 from Derived Class.");
                }
            }
        
        static void Main(string[] args)
        {

            clsA a = new();

            a.Methode1();
            a.Methode2();

            Console.WriteLine();

            clsB b = new();
            b.Methode1();
            b.Methode2();

            a = b;
            Console.WriteLine("\nAfter Casting");
            a.Methode1();
            a.Methode2();

            Console.ReadLine();
        }
    }
}
