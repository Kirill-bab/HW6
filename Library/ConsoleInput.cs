using System;

namespace Library
{
    public static class ConsoleInput
    {
        public static double GetDouble()
        {
            double result;
            var input = Console.ReadLine().Trim();
            while (!double.TryParse(input, out result))
            {
                Console.WriteLine("Wrong input! Must be a double!");
                Console.WriteLine("Try again...");
                input = Console.ReadLine().Trim();
            }

            return result;
        }

        public static int GetInt()
        {
            return (int)GetDouble();
        }
    }
}
