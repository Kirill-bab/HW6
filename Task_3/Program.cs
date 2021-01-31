using System;
using System.Diagnostics;
using System.Threading;
using Library;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {           
            Console.WriteLine("Created by Kirill");
            Console.WriteLine("This program performs login operation in multiple threads and saves attemts results in result.json file");
            Console.WriteLine();
            
            SetUp();
            Run();
            TearDown();            
        }
        /*private static string Generate(int length)
        {
            string symbols = "abcdefghigklmnopqrstuvwxyz";
            symbols += symbols.ToUpper() + "01234567789";
            string s = "";
            for (int i = 0; i < length; i++)
            {
                s += symbols[new Random().Next(symbols.Length)];
            }
            return s;
        }*/
        private static void Run()
        {
            ThreadPool.GetMinThreads(out int minThreads, out _);
            ThreadPool.GetMaxThreads(out int maxThreads, out _);
            Console.WriteLine("Please, enter amount of threads you want to use (must be between {0} " +
                "and {1}): ",minThreads,maxThreads);
            var threads = ConsoleInput.GetInt();
            while(threads < minThreads || threads > maxThreads)
            {
                Console.WriteLine();
                Console.WriteLine("Program can't run that number of threads!");
                Console.WriteLine("Please, enter amount of threads you want to use (must be between {0} " +
                "and {1}): ", minThreads, maxThreads);
                threads = ConsoleInput.GetInt();
            }
            var timer = new Stopwatch();
            timer.Start();
            for (int i = threads; i != 0; i--)
            {
                new LoginClient();
            }
            LoginClient.Waiter.Wait();
            timer.Stop();
            Console.WriteLine("Elapsed time: " + timer.Elapsed);
        }
        private static void SetUp()
        {
            var data = FileWorker.ReadLines("logins.csv");
            var userList = new User[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                var userData = data[i].Split(';');
                userList[i] = new User(userData[0], userData[1]);
            }
            LoginClient.FillUserList(userList);
            LoginClient.SetWaiter(userList.Length);
        }
        private static void TearDown()
        {
            var attempts = LoginClient.GetAttempts();
            FileWorker.Write("result.json",JsonConverter.Serialize(new Attempts(attempts.Item1,attempts.Item2)));
        }

    }
}
