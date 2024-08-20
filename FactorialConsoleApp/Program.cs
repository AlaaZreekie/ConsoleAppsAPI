using System;

namespace FactorialConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || !int.TryParse(args[0], out int number))
            {
                Console.WriteLine("Please provide an integer.");
                return;
            }

            long factorial = Factorial(number);
            Console.WriteLine($"Factorial (demo for Walaa) of {number} is {factorial}");
        }

        static long Factorial(int n)
        {
            if (n < 0) return 0; // Factorial not defined for negative numbers
            return n == 0 ? 1 : n * Factorial(n - 1);
        }
    }
}