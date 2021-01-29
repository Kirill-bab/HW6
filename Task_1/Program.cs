using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Library;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Created by Kirill");
            Console.WriteLine("This program finds primes in entered diapasone");
            Console.WriteLine();
            Run();
        }

        private static void Run()
        {
            bool isParallel = false;
            Console.WriteLine("Please, enter Start  of diapasone :");
            var from = ConsoleInput.GetInt();
            Console.WriteLine("Please, enter End  of diapasone :");
            var to = ConsoleInput.GetInt();

            Console.WriteLine("If you want to run parallel application enter \"Yes\".");
            Console.WriteLine("Othervise, enter any other answer");

            if (Console.ReadLine().Trim().ToUpper() == "YES")
            {
                isParallel = true;
            }

            Console.WriteLine("====================================");
            var timer = Stopwatch.StartNew();
            var primes = new PrimesSearcher(from, to).FindPrimes(isParallel);
            timer.Stop();
            Console.WriteLine($"Primes: {primes.Count}");
            Console.WriteLine($"Elapsed time: {timer.Elapsed}");

            Console.WriteLine("====================================");
            Console.WriteLine("Run program again?(Press Enter to run again)");
            if (Console.ReadKey(false).Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Run();
            }
        }
    }
}
