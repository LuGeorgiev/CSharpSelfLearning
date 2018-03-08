using System;


namespace ThreeVitualColumns
{
    class ThreeVirtualColumns
    {
        static void Main()
        {
            int a=6784;
            float b = 235.55968f;
            float c = -569.5623453458f;

            Console.Write("{0,-10:X}",a);
            Console.Write("{0,-10:N2}", b);
            Console.Write("{0,-10:N2}\n", c);
        }
    }
}
