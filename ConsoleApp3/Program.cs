using System;

class programm
{
    public  void funk()
    {
        int[] arra = [1, 2, 4, 5];
        int vorgabe = 3;
        
        for(int i = 0; i < arra.Length; i++)
        {
            for(int j = 0; j < arra.Length; j++)
            {
                if ((arra[i] + arra[j] == vorgabe))
                 {
                    Console.WriteLine("Vorgabe Number befindet sich in indexen " + i + " unde " +j);
                    return;
                }
            }
        }

    }

    static void Main(string[] args)
    {
        programm pro = new();
        pro.funk();
    }
}
    

