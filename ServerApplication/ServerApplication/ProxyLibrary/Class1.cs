using System;

namespace ProxyLibrary
{
    public class Proxy:MarshalByRefObject
    {
        public int square(int x)
        {
            return x * x;
        }
        public int calculator(int x, int y, int ch)
        {
            switch (ch)
            {
                case 1: return x + y;
                case 2: return x - y;
                case 3: return x * y;
                case 4: return x / y;
                default: return 0;
            }
        }
    }
}
