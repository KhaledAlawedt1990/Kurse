//using System;
//using System.Threading.Tasks;
//using System.Diagnostics;

//class Program
//{
//    static void Main()
//    {
//        // Ein großes Array von Zahlen erstellen
//        int size = 1000000;
//        int[] numbers = new int[size];
//        int[] results = new int[size];

//        int[] numbers1 = new int[size];
//        int[] results1 = new int[size];

//        // Array mit Werten füllen
//        for (int i = 0; i < size; i++)
//        {
//            numbers[i] = i;
//        }

//        for(int i = 0; i < size; i++)
//        {
//            numbers1[i] = i;
//        }

//        Stopwatch st = new Stopwatch();
//        st.Start();
//        // Normale for-Schleife verwenden, um die Quadrate der Zahlen zu berechnen
//        for (int i = 0; i < size; i++)
//        {
//            results[i] = numbers[i] * numbers[i] * numbers[i];
//        }

//        st.Stop();
//        long ForloopTime = st.ElapsedMilliseconds;
//        Console.WriteLine($"Normaler For_schleife Dauer {ForloopTime}");

//        st.Restart();

//        st.Start();

//        Parallel.For(0, size, i =>
//        {
//            results1[i] = numbers1[i] * numbers1[i] * numbers1[i];
//        });

//        st.Stop();
//        long ParallelForTime = st.ElapsedMilliseconds;
//        Console.WriteLine($"Parallel-For  Dauer {ParallelForTime}");

//        Console.WriteLine();
//        for (int i = 0; i < 10000; i++)
//        {
//            Console.WriteLine($"Parallel.For Das Quadrat von {numbers1[i]} ist {results1[i]}");
//        }

//        // Ergebnis überprüfen (zum Beispiel die ersten 10 Ergebnisse ausgeben)
//        for (int i = 0; i < 10000; i++)
//        {
//            Console.WriteLine($"Arry. Das Quadrat von {numbers[i]} ist {results[i]}");
//        }
//    }
//}






using System;
using System.Threading.Tasks;
using System.Diagnostics;


class Programm
{
    static void Main()
    {
        Console.WriteLine("Funktion Starts");

       // Parallel.Invoke(Funktion1, Funktion2, Funktion3);

        Parallel.Invoke(() =>
        {
            Console.WriteLine("Khaled");
            Console.WriteLine("Khadijah");
            Console.WriteLine("Bailiassan");
            Console.WriteLine("Hamssa");
        });
    }

    static void Funktion1()
    {
        Console.WriteLine("Function 1 is starting..");
        Task.Delay(100);
        Console.WriteLine("Function 1 is completed..");
    }

    static void Funktion2()
    {
        Console.WriteLine("Function 2 is starting..");
        Task.Delay(100);
        Console.WriteLine("Function 2 is completed..");
    }

    static void Funktion3()
    {
        Console.WriteLine("Function 3 is starting..");
        Task.Delay(100);
        Console.WriteLine("Function 3 is completed..");
    }
}