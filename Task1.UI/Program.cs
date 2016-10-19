using System;

namespace Task1.UI
{
    class Program
    {
        static double n = 5;
        static double k = 2.6;
        static Euler method;

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Input n = ");
                n = Double.Parse(Console.ReadLine());
                Console.Write("Input k = ");
                k = Double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Input Error. Using values: n = {0}, k = {1}", n, k);
            }
            method = new Euler(n, k);

            Console.WriteLine("Forecast:");
            foreach (var value in method.Forecast())
            {
                Console.WriteLine(value.x.ToString() + "\t " + Math.Round(value.y, 4));
            }
            Console.WriteLine("Correction:");
            foreach (var value in method.Correction())
            {
                Console.WriteLine(value.x.ToString() + "\t " + Math.Round(value.y, 4));
            }
            Console.ReadKey();
        }
    }
}
