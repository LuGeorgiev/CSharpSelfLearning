using System;


namespace SquareEquations
{
    class SquareEquations
    {
        static void Main()
        {
            float[] coef = new float[3];
            double x1, x2 = 0d;
            Console.WriteLine("Please, insert coeficient a, b and c of the square equation");
            for (int i = 0; i < 3; i++)
            {
                while (!float.TryParse(Console.ReadLine(), out coef[i]))
                {
                    Console.WriteLine("Duede, focus and insert viable coeficient");
                }

            }

            double discriminant= (double) coef[1]* coef[1] - 4*coef[0]*coef[2];
            if (discriminant < 0)
            {
                Console.WriteLine("There is no rational roots");                                          
            }
            else
            {
                if (coef[0] == 0)
                {
                    Console.WriteLine("There is only one root x1=" + (-coef[2] / coef[1]));
                }
                else
                {
                    x1 = (-coef[1] + Math.Sqrt(discriminant)) / 2 * coef[0];
                    x2 = (-coef[1] - Math.Sqrt(discriminant)) / 2 * coef[0];
                    Console.WriteLine("The roots fo requested equasion are/is: \nx1={0:N2}\nx2={1:N2}", x1, x2);
                }
                
            }
        }
    }
}
