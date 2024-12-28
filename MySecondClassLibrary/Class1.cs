using System;


namespace MySecondClassLibrary
{
    public class clsMyMath
    {
        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public int Multiply(int x, int y, int z)
        {
            return x * y * z;
        }

        public int Multiply(int x, int y, int z, int w)
        {
            return x * y * z * w;
        }

        public int Sum(int x, int y)
        {
            return x + y;
        }
    }
}

